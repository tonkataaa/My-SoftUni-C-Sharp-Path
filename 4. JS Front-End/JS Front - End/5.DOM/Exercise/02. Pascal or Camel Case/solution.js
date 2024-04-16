function solve() {
  let inputText = document.getElementById("text").value;
  let writingCase = document.getElementById("naming-convention").value;
  let result = document.getElementById("result");

  if (writingCase === "Pascal Case") {
    let sentance = [];
    inputText = inputText.toLowerCase();
    inputText = inputText.split(" ");
    sentance.push(inputText[0]);
    for (let index = 1; index < inputText.length; index++) {
      sentance.push(
        inputText[index].charAt(0).toUpperCase() + inputText[index].slice(1)
      );
    }
    result.textContent = sentance.join("");
  } else if (writingCase === "Camel Case") {
    let sentance = [];
    inputText = inputText.toLowerCase();
    inputText = inputText.split(" ");
    for (let index = 1; index < inputText.length; index++) {
      sentance.push(
        inputText[index].charAt(0).toUpperCase() + inputText[index].slice(1)
      );
    }
    result.textContent = sentance.join("");
  } else {
    result.textContent = "Error!";
  }
}
