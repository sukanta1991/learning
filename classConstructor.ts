class Animal{
	animalId:number;
	constructor(animalId:number){
		this.animalId=animalId;		
	}
	getAnimalId():string{
          return "animal id is"+this.animalId;
	}
}
var animal:Animal=new Animal(1234);
console.log(animal.getAnimalId());
