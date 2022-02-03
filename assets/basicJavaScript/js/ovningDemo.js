const person1 = {
  firstName: "Niklas",
  lastName: "Hjelm",
  birthDate: new Date("1987-03-30"),
};

const person2 = {
  firstName: "Szofia",
  lastName: "Jakobsson",
  birthDate: new Date("1981-09-02"),
};

const person3 = {
  firstName: "Thilde",
  lastName: "Hjelm Rasmussen",
  birthDate: new Date("2016-04-06"),
};

const person4 = {
  firstName: "Vidar",
  lastName: "Hjelm Rasmussen",
  birthDate: new Date("2018-10-24"),
};

const people = [person1, person2, person3, person4];

const temp = people.pop();

people.unshift(temp);

people.sort(function (a, b) {
  let x = a.firstName.toLowerCase();
  let y = b.firstName.toLowerCase();
  if (x < y) {
    return -1;
  }
  if (x > y) {
    return 1;
  }
  return 0;
});

for (let i = 0; i < people.length; i++) {
  const person = people[i];
  let innerHTML = `<li>${person.firstName} ${person.lastName}</li>`;
  document.getElementById("people").innerHTML += innerHTML;
}

// people.unshift(people.pop());

// const people = [
//   {
//     firstName: "Niklas",
//     lastName: "Hjelm",
//     birthDate: new Date("1987-03-30"),
//   },
//   {
//     firstName: "Szofia",
//     lastName: "Jakobsson",
//     birthDate: new Date("1981-09-02"),
//   },
//   {
//     firstName: "Thilde",
//     lastName: "Hjelm Rasmussen",
//     birthDate: new Date("2016-04-06"),
//   },
//   {
//     firstName: "Vidar",
//     lastName: "Hjelm Rasmussen",
//     birthDate: new Date("2018-10-24"),
//   },
// ];

// class Person {
//   constructor(firstName, lastName, dob) {
//     this.firstName = firstName;
//     this.lastName = lastName;
//     this.birthDate = new Date(dob);
//   }
// }

// const person2 = new Person("Szofia", "Jakobsson", "1981-09-02");

// const people = [person1, person2, person3, person4];

// people.unshift(people.pop());

// people.sort((a, b) => {
//   let x = a.firstName.toLowerCase();
//   let y = b.firstName.toLowerCase();
//   if (x < y) {
//     return -1;
//   }
//   if (x > y) {
//     return 1;
//   }
//   return 0;
// });

// for (let i = 0; i < people.length; i++) {
//   const element = people[i];
//   innerHTML = `<li><h3>${element.firstName}</h3> <h3>${element.lastName}</h3></li>`;
//   document.getElementById("people").innerHTML += innerHTML;
// }
