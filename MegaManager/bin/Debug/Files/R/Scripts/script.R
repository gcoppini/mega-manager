# We have to go deeper! Now uses as many previous values as you like!
# Added example code for hyper parameter optimisation
#
# In this script we fit linear models to each sequence using the previous N values to predict the next one
# We evaluate how well the linear model fits the sequence and fall back on using the mode as the prediction if the fit is poor
#
# Previous versions of the script experimented with quadratic models but these had a number of numerical issues

library(plyr)

Mode <- function(x)
{
  ux <- unique(x)
  ux[which.max(tabulate(match(x, ux)))]
}

# Fits a linear model based on the previous <numberOfPoints> elements in the sequence
# If <forSubmission> is true then all of the data will be used and a vector of predictions suitable for submission will be returned
# Otherwise the last element of the sequence will be held back as an out of sample test and a data frame summarising the fit will be returned
# <modeFallbackThreshold> is used when generating submissions to determine when to fall back on using the mode as the prediction
fitModel <- function(sequence,numberOfPoints,forSubmission=FALSE,modeFallbackThreshold)
{
  # Convert to a vector of numbers
  sequence <- as.numeric(strsplit(sequence,split=",")[[1]])
  if(!forSubmission)
  {
    oos <- tail(sequence,1)
    sequence <- head(sequence,-1)
  }
  
  # Need at least <numberOfPoints>+1 observations to fit the model, otherwise just return the last value
  if(length(sequence)<=numberOfPoints)
  {
    if(length(sequence)==0)
    {
      prediction <- NA
    }
    else
    {
      prediction <- tail(sequence,1)
    }
    mae <- NA
  }
  else
  {
    df <- data.frame(y=tail(sequence,-numberOfPoints))
    formulaString <- "y~"
    for(i in 1:numberOfPoints)
    {
      df[[paste0("x",i)]] <- sequence[i:(length(sequence)-numberOfPoints+i-1)]
      formulaString <- paste0(formulaString,"+x",i)
    }
    formulaString <- sub("~\\+","~",formulaString)

    fit <- lm(formula(formulaString),df)
    mae <- max(abs(fit$residuals))

    # Make prediction
    if(forSubmission && mae > modeFallbackThreshold)
    {
      prediction <- Mode(sequence)
    }
    else
    {
      df <- list()
      for(i in 1:numberOfPoints)
      {
        df[[paste0("x",i)]] <- sequence[length(sequence)-numberOfPoints+i]
      }
      df <- as.data.frame(df)
  
      prediction <- predict(fit,df)
    }

    # Round the prediction to an integer
    prediction <- round(prediction)
  }
  
  if(forSubmission)
  {
    return(prediction)
  }
  else
  {
    return(data.frame(prediction=prediction,
                      mae=mae,
                      oos=oos,
                      mode=Mode(sequence)))
  }
}

# Calculates the accuracy of predictions from calling fitModel with <forSubmission> = FALSE and a given <modeFallbackThreshold>
evaluateResults <- function(results,modeFallbackThreshold)
{
  (sum((results$prediction==results$oos)[results$mae<modeFallbackThreshold],na.rm=TRUE) +
   sum((results$mode==results$oos)[results$mae>=modeFallbackThreshold],na.rm=TRUE)) /
    sum(!is.na(results$prediction))
}

generateSubmission <- function(filename,numberOfPoints,modeFallbackThreshold,verbose=TRUE)
{
  submission <- data.frame(Id=data$Id,
                           Last=sapply(1:nrow(data),
                                       function(i)
                                       {
                                         model <- fitModel(data$Sequence[[i]],
                                                           numberOfPoints=numberOfPoints,
                                                           modeFallbackThreshold=modeFallbackThreshold,
                                                           forSubmission=TRUE)
                                         if(verbose && i %% 1000 == 0)
                                         {
                                           print(paste("Done",i,"sequences"))
                                         }
                                         return(model)
                                       }))
  options(scipen=999)
  write.csv(submission,filename,row.names=FALSE)
}

# Only ever use the test set to avoid any chance of using unauthorised information
data <- read.csv("C:\\mega.csv",stringsAsFactors=FALSE)

# Example hyper parameter optimisation
#possibleNumberOfPoints <- 8:1000
#possibleModeFallbackThresholds <- c(5,10,15,20,25,50,100,250,500,1000)

# accuracies <- matrix(NA,
#                      nrow=length(possibleNumberOfPoints),
#                      ncol=length(possibleModeFallbackThresholds))
					  
# for(numberOfPoints in possibleNumberOfPoints)
# {
#   print(paste("Trying",numberOfPoints,"points"))
#   results <- ldply(1:nrow(data),
#                    function(i)
#                    {
#                      model <- fitModel(data$Sequence[[i]],
#                                        numberOfPoints=numberOfPoints,
#                                        forSubmission=FALSE)
#                      if(i %% 1000 == 0)
#                      {
#                        print(paste("Done",i,"sequences"))
#                      }
#                      return(model)
#                    })
 
 #  for(modeFallbackThreshold in possibleModeFallbackThresholds)
 #  {
 #    accuracies[match(numberOfPoints,possibleNumberOfPoints),
 #               match(modeFallbackThreshold,possibleModeFallbackThresholds)] <- evaluateResults(results,modeFallbackThreshold)
 #  }
 #}


# Example submission generation
generateSubmission("Jogos_Gerados.csv",numberOfPoints=10,modeFallbackThreshold=5)
