import { Utility as mainUtility,Category,productName,MaxDiscountAllowed } from "./moduledemo";
let util =new mainUtility();
let price=util.CalculateAmount(1350,4);

let discount=MaxDiscountAllowed(2);
console.log(`Maximum discount allowed is: ${discount}`);

console.log(`Amount to be paid: ${price}`);
console.log(`ProductName is: ${productName}`);
