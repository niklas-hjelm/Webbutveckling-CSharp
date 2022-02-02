function addNumbers(numOne, numTwo) {
  return numOne + numTwo;
}

function wohoo() {
  one = 6;
  document.getElementById("testList").innerHTML = "";
  while (one > 0) {
    document.getElementById("testList").innerHTML += `<li>${--one}</li>`;
  }
}

var one = 6;
var two = 6;

const result = one / two;

if (one === two) {
  let res2 = one + two;
  document.getElementById("test").innerHTML = res2;
} else if (one == two) {
} else {
  document.getElementById("test").innerHTML = "Fail!";
}

// for (let i = 6; i > 0; i--) {
//   document.getElementById("testList2").innerHTML += `<li>${i}</li>`;
// }

document.getElementById("summa").innerHTML += ` ${addNumbers(6, 2)}`;

document.getElementById("namn").innerHTML = "Niklas";
document.getElementById("namn2").innerHTML = "Niklas2";

document.getElementById("leaves").src = "images/picTwo.jpeg";
document.getElementById("namn2").style.color = "red";
document.getElementById("namn").style.color = "black";
document.getElementById("leaves").style.borderRadius = "50%";
