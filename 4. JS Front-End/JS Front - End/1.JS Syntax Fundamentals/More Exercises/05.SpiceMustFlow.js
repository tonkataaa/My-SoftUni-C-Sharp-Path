function solve(startYield) {
    let daysCount = 0;
    let extractedSpice = 0;
    while (startYield >= 100) {

        daysCount++;
        extractedSpice += startYield;
        extractedSpice -= 26;
        startYield -= 10;
    }

    if (daysCount > 0)
    {
        extractedSpice -= 26;
        if (extractedSpice < 0){
            extractedSpice = 0;
        }
    }

    console.log(daysCount);
    console.log(extractedSpice);

}

solve(111);
solve(450);