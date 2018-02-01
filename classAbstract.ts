abstract class Animal{
	getFeatures():void{
		
	}
	abstract getAnimalName():string;
	}	
class Dog extends Animal{
getAnimalName():string{
	return "AnimalName is German Shepard";
	}		
}
class Cat extends Animal{
	getAnimalName():string{
	return "AnimalName is house cat";
	}
}
var g=new Dog();
console.log(g.getAnimalName());
var c=new Cat();
console.log(c.getAnimalName());
