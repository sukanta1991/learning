let persons = [{ "name": "Tony","limit":15000 },

        { "name": "Stark","limit":20000 },

        { "name": "mark","limit":40000  },

        { "name": "Henry","limit":10000  }

    ];

let test;

function myFunction() {

  test = persons.filter((person)=>person.limit>=20000);

}

myFunction();

console.log("The filtered array is");

for (let i = 0; i < test.length; i++)

{

    console.log(test[i].name);

}
