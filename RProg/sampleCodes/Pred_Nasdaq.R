cpx <- read.xlsx("complexRel.xlsx",1)
head(cpx,1)
sam <- sample(1:nrow(cpx),floor(0.85*nrow(cpx)))
train <- cpx[sam,]
test <- cpx[-sam,]
nrow(train)
nrow(test)
plot(cpx[,-2],main="Predict Nasdaq")
cpMod <- lm(NQOpen ~ FEClose + NTClose+GBINClose+USINClose+DY,data=train)
summary(cpMod)
pred <- predict(cpMod,test)
write.csv(pred,"Output.csv")
