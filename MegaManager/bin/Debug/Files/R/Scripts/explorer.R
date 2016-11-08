library(data.table)

#let's acquire the train and test datasets
test = fread("C:\\test.csv", data.table = FALSE)
train = fread("C:\\train.csv", data.table = FALSE)

detach("package:data.table", unload=TRUE)

#I copied this one from https://www.kaggle.com/jamesdlawrence/integer-sequence-learning/integer-guessatron
test = list(Id=test$Id, seq = sapply(as.character(test$Sequence), function(x) as.numeric(unlist(strsplit(x,",")))))
train = list(Id=train$Id, seq = sapply(as.character(train$Sequence), function(x) as.numeric(unlist(strsplit(x,",")))))

names(train$seq) = train$Id
names(test$seq) = test$Id

par(mfrow = c(1,2))
hist(unlist(lapply(train[[2]], length)), xlab = "Length", main = "dataset: train")
hist(unlist(lapply(test[[2]], length)), xlab = "Length", main = "dataset: test")

op = par(mfrow = c(10,10),
          oma = c(5,4,0,0) + 0.1,
          mar = c(0,0,1,1) + 0.1)
for (n in sample(1:length(train[[2]]),100)) plot(seq(1,length(train[[2]][[n]])),abs(train[[2]][[n]])+ 1, log = "y", type = "o", pch = 16, axes = FALSE, col = c("red","black","black")[2+sign(train[[2]][[n]])])
for (n in sample(1:length(test[[2]]),100)) plot(seq(1,length(test[[2]][[n]])),abs(test[[2]][[n]])+ 1, log = "y", type = "o", pch = 16, axes = FALSE, col = c("red","black","black")[2+sign(test[[2]][[n]])])