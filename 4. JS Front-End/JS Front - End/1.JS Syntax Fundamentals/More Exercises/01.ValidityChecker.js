function checker(x1, y1, x2, y2) {
    let firstDistance = Math.sqrt(x1 * x1 + y1 * y1);
    if (firstDistance % 1 == 0){
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }
    
    let secondDistance = Math.sqrt(x2 * x2 + y2 * y2);
    if (secondDistance % 1 == 0)
    {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`)
    } else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`)
    }
    
    let calculateDistance = Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
    if (calculateDistance % 1 == 0) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`)
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }

}

checker(3, 0, 0, 4);
checker(2, 1, 1, 1);