function checkSameDigitsAndSum(number) {
    const numString = number.toString();
    let areDigitsSame = true;
    let sum = 0;

    for (let i = 1; i < numString.length; i++) {
        if (numString[i] !== numString[0]) {
            areDigitsSame = false;
            break;
        }
    }

    for (let digit of numString) {
        sum += parseInt(digit);
    }

    console.log(areDigitsSame);
    console.log(sum);
}
