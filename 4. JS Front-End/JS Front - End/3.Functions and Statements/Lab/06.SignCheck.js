function checker(numOne, numTwo, numThree) {
    let negativesCount = 0;

    if (numOne === 0 || numTwo === 0 || numThree === 0) {
        console.log("Positive");
        return;
    }

    if (numOne < 0) {
        negativesCount++;
    }
    if (numTwo < 0) {
        negativesCount++;
    }
    if (numThree < 0) {
        negativesCount++;
    }

    if (negativesCount % 2 === 0) {
        console.log(`Positive`);
    } else {
        console.log(`Negative`);
    }
}


checker(5, 12, -15);
checker(-6, -12, 14);
checker(-1, -2, -3);
checker(-5, 1, 1);