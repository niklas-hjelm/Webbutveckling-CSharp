const jsonMaträtter =
  '[{"protein": "kyckling", "carb": "pasta", "sauce": "tomato"}]';

const maträtter = JSON.parse(jsonMaträtter);

const jsonRequest = new Request("js/people.json");

const people = [];

class Person {
  constructor(input) {
    this.firstName = input.firstName;
    this.lastName = input.lastName;
    this.birthDate = new Date(input.birthDate);
  }
}

function populatePeopleList(array) {
  for (let i = 0; i < array.length; i++) {
    const person = array[i];
    let innerHTML = `<li>${person.firstName} ${person.lastName}</li>`;
    document.getElementById("people").innerHTML += innerHTML;
  }
}

fetch(jsonRequest)
  .then((response) => response.json())
  .then((data) => {
    for (let i = 0; i < data.length; i++) {
      const person = new Person(data[i]);
      people.push(person);
    }
    populatePeopleList(people);
  })
  .catch(console.error);
