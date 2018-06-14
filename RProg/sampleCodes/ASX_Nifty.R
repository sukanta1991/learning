cpx <- read.xlsx("ASXtoNIFTY.xlsx",1)
sam <- sample(1:nrow(cpx),floor(0.85*nrow(cpx)))
train <- cpx[sam,]
test <- cpx[-sam,]
plot(cpx[,c("Date","AXOpen","NYOpen","AUINClose")],main="ASX to NIFTY")
axMod <- lm(NYOpen ~ AXOpen + AUINClose + DY,data=train)
summary(axMod)
preds <- predict(axMod,test)
write.csv(preds,"gola.csv")

