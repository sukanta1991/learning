let productAvailable: [string, boolean];

let productName;

let availability;

 productAvailable = ["Samsung Galaxy J7",true,"Samsung Galaxy J5",false];

 for (let i = 0; i < productAvailable.length; i++) {

     if (typeof productAvailable[i] == "string")

         productName = productAvailable[i];

     else if (typeof productAvailable[i] == "boolean") {

         availability = productAvailable[i];

         if (availability === true)

             console.log(`The product ${productName} is available`);

         else if (availability === false)

             console.log(`The product ${productName} is not available`);

     }

}
