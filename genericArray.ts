function orderDetails<T>(arg: Array<T>): Array<T> {
    console.log(arg.length);  
    return arg;
}

let orderid:Array<number>=[101,102,103,104];
let ordername:Array<string>=['footwear','dress','cds','toys'];
let idList=orderDetails(orderid);
console.log(idList);
let nameList=orderDetails(ordername);
console.log(nameList);
