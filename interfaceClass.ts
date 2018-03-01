interface Product{
	getProductDetails():string[];	
	displayProductName:(prouctId:number)=>string;
}

class Gadget implements Product{
    getProductDetails(): string[]{
        return ["Samsung","LG","Moto"];
	}	
	displayProductName(productId:number):string{
		if(productId==101)
            return "Product Name is Mobile";
        else if(productId==201)
		  return "Product Name is Tablet";
    }	
    
    getGadget(): string[] { 
        return ["Mobile","Tablet","iPad","iPod"];
    }        
}
let g:Product=new Gadget();
let productName: string = g.displayProductName(101);
console.log(productName);
let productDetails: string[] = g.getProductDetails();
console.log("The available products are "+g.getProductDetails());
