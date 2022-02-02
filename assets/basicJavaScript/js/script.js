let one = 6,
  two = 6,
  counterVariable = 0;

const result = one / two;

function addNumbers(numOne, numTwo) {
  return numOne + numTwo;
}

function showList() {
  while (one > 0) {
    document.getElementById("testList").innerHTML += `<li>${--one}</li>`;
  }
}

function clearList() {
  one = 6;
  document.getElementById("testList").innerHTML = "";
}

function showAlert() {
  alert("Detta är en alert-box!");
}

function counter() {
  counterVariable++;
}

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

document.getElementById("namn").innerHTML = "<p>Apa</p>";
document.getElementById("namn2").innerHTML = "Niklas2";

// document.getElementById("leaves").src = "images/picTwo.jpeg";
document.getElementById("namn2").style.color = "red";
document.getElementById("namn").style.color = "black";
// document.getElementById("leaves").style.borderRadius = "50%";

function varTest() {
  var test = 0;
  while (test < 5) {
    test++;
    let a = 0;
  }
  let a = 0;
}
