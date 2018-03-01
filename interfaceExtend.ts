interface Category{
    categoryName:string;
    }
    interface Product{
        productName:string;
        productId:number;	
    }
    interface productList extends Category,Product{
        list:Array<string>;	
    }
    let productDetails:productList={
        categoryName:'Gadget',
        productName:'Mobile',
        productId:1234,
        list:['Samsung','Motorola','LG']
    }
    let listProduct = productDetails.list;
    let pname: string = productDetails.productName;
    console.log("ProductName is " + pname);
    console.log("Product List is " + listProduct);
    
