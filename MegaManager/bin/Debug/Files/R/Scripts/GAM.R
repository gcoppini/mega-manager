library(readr)
library(caret)
library(gam)
options(scipen=999)

test <- read_csv(file = "C:\\mega.csv")
#test <- test[1:11384*5,]
test <- test[11384*5+1:nrow(test),]
test_list <- list(Id=test$Id, seq = sapply(as.character(test$Sequence), function(x) as.numeric(unlist(strsplit(x,",")))))

last_elements <- as.numeric(unlist(lapply(test_list$seq,FUN = function(x){tail(x,1)})))
infs <- which(is.nan(last_elements)==TRUE)
# Courtesy of https://www.kaggle.com/wcukierski/integer-sequence-learning/mode-benchmark/
  Mode <- function(x) {
  ux <- unique(x)
  ux[which.max(tabulate(match(x, ux)))]
}

Integer_guesser <- function(sequence){
 
  if(length(sequence)<=2){
    prediction <- tail(sequence,1)
  }
  else{
      df <- as.data.frame(rbind(c(y=sequence[length(sequence)],head(sequence,-1))))
      fit_model <- gam(y~.,data = df,family = "gaussian")
      prediction <- round(predict(fit_model,df))
  }
  return(prediction)
}

submission <- data.frame(Id=test_list$Id,Last=sapply(test_list$seq,Integer_guesser))
write.csv(submission,"gam_fitter1.csv",row.names=FALSE)