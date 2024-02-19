function mathOperations(num1, num2, symbol){
    switch(symbol){
        case '+':
            console.log(num1 + num2);
            break;
        case '-':
            console.log(num1 - num2);
            break;
        case '*':
            console.log(num1 * num2);
            break;
        case '/':
            console.log(num1 / num2);
            break;
        case '%':
            console.log(num1 % num2);
            break;
        case '**':
            console.log(num1 ** num2);
            break;
    }
}

mathOperations(5, 6, '+');
mathOperations(3, 5.5, '*');