function calculator (numOne, numTwo, operator) {
    const operations = {
        'multiply': (a, b) => numOne * numTwo,
        'divide': (a, b) => numOne / numTwo,
        'add': (a, b) => numOne + numTwo,
        'subtract': (a, b) => numOne - numTwo
    };

    console.log(operations[operator](numOne, numTwo));
};

calculator(5, 5, `multiply`);
calculator(40, 8, `divide`);
calculator(12, 19, `add`);
calculator(50, 13, `substract`);