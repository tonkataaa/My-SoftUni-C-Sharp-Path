function solve(lostFights, helmetPrice, swordPrice, shieldPrice, armorPrice) {

    let neededMoney = 0;
    let shieldBrakesCount = 0;
    for (let i = 1; i <= lostFights; i++) {
        if (i % 2 == 0) {
            neededMoney += helmetPrice;
        }

        if (i % 3 == 0) {
            neededMoney += swordPrice;
        }

        if (i % 2 == 0 && i % 3 == 0) {
            neededMoney += shieldPrice;
            shieldBrakesCount++;
        }

        if (shieldBrakesCount > 0 && shieldBrakesCount % 2 == 0) {
            neededMoney += armorPrice;
            shieldBrakesCount = 0;
        }

    }
    console.log(`Gladiator expenses: ${neededMoney.toFixed(2)} aureus`);


}


// solve(7, 2, 3, 4, 5);
solve(23, 12.50, 21.50, 40, 200);