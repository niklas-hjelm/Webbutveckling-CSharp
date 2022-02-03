const animals = ["Dog", "Cat", "Rat"];

animals.push("Bird");

let bird = animals.pop();

let dog = animals.shift();

animals.unshift(dog);

animals.unshift(bird);

animals.push(1);

animals.push(true);

animals[4] = "Fish";

animals[animals.length - 1] = "Hedgehog";

delete animals[0];

animals[0] = "Lizard";

// for (let i = 0; i < animals.length; i++) {
//   delete animals[i];
// }

var text = "Snake Cricket Cow";

const animalsFromText = text.split(" ");

const allAnimals = animalsFromText.concat(animals);

const people = ["Niklas", "Göran"];

const everything = people.concat(animals, animalsFromText);

const newNames = ["Per", "Petter"];

everything.splice(2, 0, "Per", "Petter", "Fabian");

const fewNames = everything.slice(2, 5);
