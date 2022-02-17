const jsonFoodBefore =
  '[{"protein":"egg","carb":"potatoes","sauce":"ketchup"},{"protein":"chicken","carb":"rice","sauce":"soy"},{"protein":"bacon","carb":"bread","sauce":"mayonnaise"},{"protein":"beef","carb":"sweet potatoes","sauce":"bbq"}]';
console.log(jsonFoodBefore);

const foodArr = JSON.parse(jsonFoodBefore);
console.log(foodArr);

const jsonFoodAfter = JSON.stringify(foodArr);
console.log(jsonFoodAfter);

for (let i = 0; i < foodArr.length; i++) {
  const food = foodArr[i];
  const foodListItem = `<li>Protein: ${food.protein}, Carb: ${food.carb}, Sauce: ${food.sauce}</li>`;
  document.getElementById("food-list").innerHTML += foodListItem;
}

async function fetchFood() {
  const response = await fetch("js/food.json");
  const data = response.json();
  for (let i = 0; i < data.length; i++) {
    const dish = data[i];
  }
}

fetchFood();

fetch(new Request("js/food.json"))
  .then((response) => response.json())
  .then((data) => {
    for (let i = 0; i < data.length; i++) {
      const dish = data[i];
    }
  });
