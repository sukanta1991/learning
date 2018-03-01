class Gadget <T>{
	productList:Array<T>;
addItems(newItemList:Array<T>):void{
	this.productList=newItemList;
	console.log("Item added");
}
getProductList():Array<T>{	
return this.productList;
}
}
let product=new Gadget<string>();
let productList:Array<string>=["Mobile","Tablet","Ipod"];
product.addItems(productList);
let allProducts:Array<string>=product.getProductList();
console.log("The available products"+allProducts);

let product2=new Gadget<number>();
let shippingList:Array<number>=[123,234,543];
product2.addItems(shippingList);
let allItems:Array<number>=product2.getProductList();
console.log("The available shipping ids"+ allItems);
