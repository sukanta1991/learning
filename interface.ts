interface Product{
	productId:number;
	productName:string;	
}
function getProductDetails(productobj:Product):string{
    return "The product name is "+productobj.productName;
}

let prodObject={productId:1001,productName:'Mobile'};
let productDetails:string=getProductDetails(prodObject);

console.log(productDetails);
