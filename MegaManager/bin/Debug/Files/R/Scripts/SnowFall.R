## first, read the training data
## only kidding! Real data scientists don't need no training data!

read.csv("C:\\mega.csv") -> test
test <- list(Id=test$Id,seq=sapply(as.character(test$Sequence),function(x)as.numeric(unlist(strsplit(x,",")))))

## function to try to predict the next one
## for each sequence, predict either x[n], x[n-1], x[n-2] or mode(x)
## depending on whether that performs best for that particular sequence
## truncated at every point after halfway
## if the sequence is really short, just predict the last value

predictNext <- function(x){
	if(length(x) <= 8) return(x[length(x)])
	test <- x[ti <- (length(x)/2):length(x)]
	p1 <- x[ti-1]
	p2 <- rep(as.numeric(names(summary.factor(x[1:(length(x)/2)])[1])),length(ti))
	p3 <- x[ti-2]
	p4 <- x[ti-3]
	pp <- c(sum(p1==test),sum(p2==test),sum(p3==test),sum(p4==test))
	switch(which.max(pp),
		x[length(x)],
		as.numeric(names(summary.factor(x[1:(length(x)/2)])[1])),
		x[length(x)-1],
		x[length(x)-2]
    )
}

## predict in parallel
## data science always works better when done in parallel

library(snowfall)
sfInit(parallel=TRUE,cpus=5)
sfExport("test","predictNext")

testPreds <- sfSapply(test$seq,predictNext)
#read.csv("C:\\sample_submission.csv") -> ss
#ss$Last <- unname(testPreds)

## we need this option so we don't write "1e5" instead of "10000"
options(scipen=300)
#write.csv(ss,file="guessatron_006942.csv",row.names=FALSE)
write.csv(testPreds,file="guessatron_006942.csv",row.names=FALSE)

sfStop()