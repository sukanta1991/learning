interface Product{
	productId?:number;
	productName:string;	
}
function getProductDetails(productobj:Product):string{
    return "The product name is "+productobj.productName;
}

let prodObject={productName:'Mobile',productCategory:'Gadget'};
let productDetails:string=getProductDetails(prodObject);

console.log(productDetails);
