 class Animal{
	protected animalId:number;
	constructor(animalId:number){
		this.animalId=animalId;		
	}	
	getAnimal():void{
		console.log("AnimalID"+ this.animalId);
}}
class Dog extends Animal{
	constructor(public animalName:string,animalId:number){
		super(animalId);
	}	
	getAnimal():void{
		super.getAnimal();
		console.log("AnimalID: "+ this.animalId+" AnimalName: "+this.animalName);
	}
}
var g=new Dog("Alsatian",952);
g.getAnimal();
