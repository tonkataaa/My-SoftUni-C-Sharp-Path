function sum(num1, num2, num3) {
    let result = num1 + num2;

    let subtract = function (num3) {
        return result - num3;
    }

    console.log(subtract(num3)); 
}

sum(23, 6, 10);
sum(1, 17, 30);
sum(42, 58, 100);