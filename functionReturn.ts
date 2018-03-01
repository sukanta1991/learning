function getMobileByManufacturer(manufacturer: string): string[]{

        let MobileList: string[];
    
        if (manufacturer == "Samsung") {
    
            MobileList = ["Samsung Galaxy S6 Edge","Samsung Galaxy Note 7",
    
    "Samsung Galaxy J7 SM-J700F"];
    
            return MobileList;
    
        }
    
        else if (manufacturer == "Apple") {
    
        MobileList = ["Apple iPhone 5s","Apple iPhone 6s ","Apple iPhone 7"];
    
            return MobileList;
    
        }
    
        else {
    
        MobileList = ["Nokia 105","Nokia 230 Dual Sim"];
    
            return MobileList;
    
        }
    
    }
    
    console.log("The available mobile list:"+getMobileByManufacturer("Samsung"));
