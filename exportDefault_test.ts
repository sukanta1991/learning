import Gift,{Utility} from './exportDefault';
let gift = new Gift();
let details=gift.getGiftDetails(1001);
console.log(details);
let util =new Utility();
let price=util.CalculateAmount(1300,4);
console.log(`The price is ${price}`);
