function solve(number){
    let textNum = number.toString();
    let sum = 0;

    for (let i = 0; i < textNum.length; i++) {
        
        sum += Number(textNum[i]);
    }
    console.log(sum);

}

solve(245678);
solve(97561);
solve(543);