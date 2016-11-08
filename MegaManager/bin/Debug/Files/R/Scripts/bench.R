library(dplyr)
library(readr)
library(stringr)
set.seed(1234)
options(scipen=999) #Important: prevents scientific notation when writing big integers

test <- read_csv("C:\\mega.csv")

# Because R's mode() tells you the internal storage format ┌( ಠ_ಠ)┘
Mode <- function(x) {
  ux <- unique(x)
  ux[which.max(tabulate(match(x, ux)))]
}

# Parse string sequence to a list of integers
parseSequence <- function(str) {
  return(as.numeric(str_split(str, ",")[[1]]))
}

modeBenchmark <- test %>%
  rowwise() %>%
  mutate(Last = Mode(parseSequence(Sequence))) %>%
  select(Id, Last) %>%
  arrange(Id) %>%
  write_csv(., "mode_benchmark.csv")
    