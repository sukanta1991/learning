interface Inventory<T> {
    addItem: (newItem: T) => void;
    getProductList: () => Array<T>;
    }
    
    class Gadget implements Inventory<string>{
    addItem(newItem:string):void{
    console.log("Item added");
    }
    productList:Array<string>=["Mobile","Tablet","Ipod"];
    getProductList():Array<string>{
    return this.productList;
    }
    }
    let productInventory:Inventory<string>=new Gadget();
    let allProducts:Array<string>=productInventory.getProductList();
    console.log("The available products are:"+allProducts);
    
    class Shipping implements Inventory<number>{
    addItem(newItem:number):void{
    console.log("Item added");
    }
    shippingID:Array<number>=[123,234,543];
    getProductList():Array<number>{
    return this.shippingID;
    }
    }
    let shippingInventory:Inventory<number>=new Shipping();
    let shippingIDs:Array<number>=shippingInventory.getProductList();
    console.log("The shipping IDs:"+shippingIDs);
    
