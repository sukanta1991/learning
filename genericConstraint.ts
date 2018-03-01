interface AddLength{
	length:number;
}


function orderLength<T extends AddLength>(arg:T): T{
    let lengthValue=arg.length;  
	console.log("Length is "+lengthValue);
    return arg;
}

class Product implements AddLength{
	length:number=10;
}
let product:Product=new Product();
let product1=orderLength(product);
console.log("Product Length"+product1.length);

let ordername:Array<string>=['footwear','dress','cds','toys'];
let order1=orderLength(ordername);
console.log("Order length is"+order1.length);
