function repeat(string, repeatCount){
    let result = "";
    for (let i = 0; i < repeatCount; i++) {
        result += string;    
    }
    console.log(result);
}

repeat('abc', 3);
repeat(`String`, 2)