class Animal{
	private animalId:number;
	public animalName:string;
	static animalPrice: number=15000;
	protected animalBreed:string;
	constructor(animalId:number,animalName,animalBreed){
		this.animalId=animalId;	
		this.animalName=animalName;		
		this.animalBreed=animalBreed;				
	}	
	getAnimalId(){
	console.log("The animalId is "+this.animalId);
	}
	
}
class Dog extends Animal{
	getAnimal():void{
		console.log("AnimalBreed: "+ this.animalBreed);
	}		
}
var g:Dog=new Dog(1234,"Alsatian","German Shepherd");
g.getAnimal();
g.getAnimalId();
console.log("AnimalName is " + g.animalName);
console.log("Animal price is:" + Animal.animalPrice);
