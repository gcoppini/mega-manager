# Load the data
train <- read.csv("C:\\mega.csv",stringsAsFactors=FALSE)
sequences <- strsplit(train$Sequence,split=",")

# Predict and visualize
indexes <- 1:6

items <- lapply(sequences[indexes], as.numeric)

par(mfrow=c(3,4))
options(warn=-1) # do not show warnings in the output

for (index in 1:6) {
  current <- unlist(items[index])
  nextX <- length(current) + 1

  data <- data.frame(y = current, x = 1:length(current))
        
  # Polynom degree 
  degree <- length(unique(current)) - 1
    
  fit <- lm(y ~ poly(x, degree, raw = TRUE), data)
  predicted <- predict(fit, data.frame(x = nextX))
    
  #Visualize  
  plot(current, type = "b", main = paste(index, predicted, sep=" - "), ylab = "Value", 
       xlim = c(0, nextX + 1), 
       ylim = c(0, max(predicted, current[nextX - 1]))
  )  
 
  points(nextX, predicted, type = "p", col = "red")
  
  predicted
}