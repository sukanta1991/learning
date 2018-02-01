enum GiftPrice{Silver=25000,Gold=28000,Diamond=30000};

function calculateAmount(price:number):number{
    let discount: number;
    let totalAmount: number;
if(price==GiftPrice.Gold)
      discount=5;
else if(price==GiftPrice.Diamond)
  discount=8;
else
    discount = 10;
totalAmount =price-price * discount / 100;
return totalAmount;
}
console.log("Actual price of the Gift is " + GiftPrice.Silver);
console.log("The final price after discount is "+calculateAmount(GiftPrice.Silver));
