const person = {
  firstName: "Nichlas",
  lastName: "Hjelm",
  birthDate: new Date("1987-03-30"),
  fullName: function () {
    return `${this.firstName} ${this.lastName}`;
  },
};

person.firstName = "Niklas";

person["age"] = 34;

document.getElementById("fullName").innerHTML = person.fullName();

const todaysDate = new Date();
const myDate = new Date(1992, 1, 30, 8, 30);
const todaysDateFormat = new Date("2018-02-1");
