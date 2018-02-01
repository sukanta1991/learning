export default class{
    giftName: string="iPhone";
    getGiftDetails(giftId:number):string{
        return "GiftId:  "+giftId+"GiftName is "+this.giftName;
    }
    }
    
    export class Utility {
    CalculateAmount(price: number, quantity: number): number {
        return price * quantity;
    }
        
    }
    
