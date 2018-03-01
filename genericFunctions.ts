function printData<T>(data:T):T{
    return data;
    }
    let data:string=printData<string>('Hello Generics');
    console.log("String data"+data);
    
    class Product{
        productName:string;	
    }
    
    let productData:Product={productName:'Tablet'};
    let data2:Product=printData<Product>(productData);
    console.log("Object data"+data2);
    
