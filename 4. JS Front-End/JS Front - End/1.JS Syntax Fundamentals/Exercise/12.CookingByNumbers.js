function operations(number, operations) {
    let result = Number(number);

    for (let op of operations) {
        switch (op) {
            case 'chop':
                result /= 2;
                break;
            case 'dice':
                result = Math.sqrt(result);
                break;
            case 'spice':
                result += 1;
                break;
            case 'bake':
                result *= 3;
                break;
            case 'fillet':
                result -= result * 0.20;
                break;
        }
        console.log(result); 
    }
}

operations('32', ['chop', 'chop', 'chop', 'chop', 'chop']);
operations(`9`, ['dice', 'spice', 'chop', 'bake', 'fillet']);