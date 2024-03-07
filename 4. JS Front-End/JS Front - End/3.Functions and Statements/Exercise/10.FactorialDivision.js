function factorial(firstNum, secondNum) {
    let factorialSum = function(firstNum, secondNum){
        let firstNumresult = 1;
        for (let i = 1; i <= firstNum; i++) {
            firstNumresult *= i;
        }

        let secondNumResult = 1;
        for (let j = 1; j <= secondNum; j++) {
            secondNumResult *= j;        
        }

        let divide = firstNumresult / secondNumResult

        return divide.toFixed(2);
    }

    console.log(factorialSum(firstNum, secondNum));
}

factorial(5, 2);
factorial(6, 2);

