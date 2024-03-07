function evenAndOddSum(number) {
    let sum = function (number) {
        let digits = [];
        while (number != 0) {
            digits.push(number % 10);
            number = Math.trunc(number / 10);
        }
        digits.reverse();

        let evenSum = 0;
        let oddSum = 0;
        for (let digit of digits) {
            if (digit % 2 == 0) {
                evenSum += digit;
            } else {
                oddSum += digit;
            }
        }

        return { oddSum, evenSum };
    }
    const result = sum(number);
    console.log(`Odd sum = ${result.oddSum}, Even sum = ${result.evenSum}`);
}

evenAndOddSum(1000435);
evenAndOddSum(3495892137259234);