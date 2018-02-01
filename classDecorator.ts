function invoke(constructor:Function) {
    // the new constructor behaviour
   var newconstructor : any = function (...args) {     
      this.animalId=625;
      this.animalName="Cat";
      }	 
  // return newconstructor will override the original constructor
   return newconstructor;
 }
 @invoke
 class Animal { 
   public animalId: number;
   public animalName: string;
   constructor(animalId : number, animalName : string) {     
     this.animalId = animalId;
     this.animalName = animalName;
       }
 }
 var p = new Animal(158, "Dog");
 console.log(`Animal id is: ${p.animalId}`);
 console.log(`Animal name is : ${p.animalName}`);
 
