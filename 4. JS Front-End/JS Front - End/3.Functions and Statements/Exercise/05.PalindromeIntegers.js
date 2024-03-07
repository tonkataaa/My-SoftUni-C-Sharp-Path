function palindromeNum(arrayOfNums) {
    for (let number of arrayOfNums) {
        let numToString = number.toString();
        let reversedNumber = numToString.split('').reverse().join('');
        if (number == reversedNumber) {
            console.log(`true`);
        } else {
            console.log(`false`);
        }
    }
}

palindromeNum([123, 323, 421, 121]);
palindromeNum([32, 2, 232, 1010]);