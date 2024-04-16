function subtract() {
    let firstNum = document.getElementById("firstNumber").value;
    let secondNum = document.getElementById("secondNumber").value;
    let result = document.getElementById("result");

    let substraction = Number(firstNum) - Number(secondNum);
    result.textContent = substraction;
}