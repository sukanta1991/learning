namespace Utility {
    export namespace Payment {
    export function CalculateAmount(price: number,quantity:number): number {
        return price*quantity;
    }
}
    export function MaxDiscountAllowed(noOfProduct: number): number {
    if (noOfProduct >5) {
        return 40
    } else {
        return 10;
    }
}
    function privateFunc(): void {
    console.log('This is private...');
}
}
