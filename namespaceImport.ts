/// <reference path="./namespacedemo.ts" />

import util = Utility.Payment;

let paymentAmount = util.CalculateAmount(1255,6);
console.log(`Amount to be paid: ${paymentAmount}`);
let discount=Utility.MaxDiscountAllowed(6);
console.log(`Maximum discount allowed is: ${discount}`);
