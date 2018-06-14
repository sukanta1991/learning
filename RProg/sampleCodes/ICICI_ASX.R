ici <- read.xlsx("Icicrel.xlsx",1)
head(ici,1)
sam <- sample(1:nrow(ici),floor(0.85*nrow(ici)))
train <- ici[sam,]
test <- ici[-sam,]
mods <- lm(CDOpen ~ PDClose + ASXOpen,data=train)
summary(mods)
preds <- predict(mods,test)
write.csv(preds,"molla.csv")
plot(ici[,c("PDClose","ASXOpen","CDOpen")],main="Predict ICICI Open")
