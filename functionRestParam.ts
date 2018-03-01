let cart: string[]=[];

let pushtoCart = (productName: string) => { cart.push(productName); }

function addtoCart(...productName: string[]): string[]{

    for (let i = 0; i < productName.length; i++) {

        pushtoCart(productName[i]);      

    } 

    return cart;

}

console.log("Cart Items are:"+addtoCart("Moto G Play, 4th Gen","Apple iPhone 5s"));
