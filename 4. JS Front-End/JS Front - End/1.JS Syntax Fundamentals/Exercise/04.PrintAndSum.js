function sumOfNumbers(start, end) {
    let sum = 0;
    let numbers = [];
    for (let index = start; index <= end; index++) {
        numbers.push(index);
        sum = sum + index;
    }
    console.log(numbers.join(" "));
    console.log(`Sum: ${sum}`);
}

sumOfNumbers(5, 10);
sumOfNumbers(0, 26);
sumOfNumbers(50, 60);