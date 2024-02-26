function radar(speed, area) {
    let overSpeed = 0;

    if (area == `city`) {

        if (speed <= 50) {
            console.log(`Driving ${speed} km/h in a 50 zone`);
        } else {
            overSpeed = speed - 50;
            if (overSpeed <= 20) {
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 50 - speeding`);
            } else if (overSpeed > 20 && overSpeed <= 40) {
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 50 - excessive speeding`);
            } else {
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 50 - reckless driving`);
            }
        }
    } else if (area == `residential`) {
        if (speed <= 20) {
            console.log(`Driving ${speed} km/h in a 20 zone`);
        }else {
            overSpeed = speed - 20;
            if (overSpeed <= 20) {
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 20 - speeding`);
            } else if (overSpeed > 20 && overSpeed <= 40) {
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 20 - excessive speeding`);
            } else {
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 20 - reckless driving`);
            }
        }

    } else if (area == `interstate`) {
        if (speed <= 90) {
            console.log(`Driving ${speed} km/h in a 90 zone`);
        } else {
            overSpeed = speed - 90;
            if (overSpeed <= 20) {
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 90 - speeding`);
            } else if (overSpeed > 20 && overSpeed <= 40) {
                console.log(`The spped is ${overSpeed} km/h faster than the allowed speed of 90 - excessive speeding`);
            } else {
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 90 - reckless driving`);
            }
        }

    } else if (area == `motorway`) {
        if (speed <= 130) {
            console.log(`Driving ${speed} km/h in a 130 zone`);
        } else {
            overSpeed = speed - 130;
            if (overSpeed <= 20) {
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 130 - speeding`);
            } else if (overSpeed > 20 && overSpeed <= 40) {
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 130 - excessive speeding`);
            } else {
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 130 - reckless driving`);
            }
        }
    }

}

radar(40, `city`);
radar(21, `residential`);
radar(120, `interstate`);
radar(200, `motorway`);
