function logMethod(){

    return function (target, propertyKey: string, descriptor: PropertyDescriptor) {
	return {
        value: function( ... args: any[]) {	
            
            console.log(target);
            console.log("--------------------------")
            console.log(propertyKey);
            console.log("--------------------------")
            console.log(descriptor);
            console.log("--------------------------")
            console.log("Arguments: ", args.join(", "));
           const result = descriptor.value.apply(target, args);
            console.log("Total Payable Amount is: ", result);
            return result;
        }
		}
    }
}
 
 
class Product {
 
    @logMethod()
    calculateAmountPayable(price: number, quantity: number) {
	        return price*quantity;
    }
}
 
 let p:Product =new Product();
p.calculateAmountPayable(220, 3);
