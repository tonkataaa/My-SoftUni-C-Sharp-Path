function vacationPrice(group, typeOfGroup, dayOfWeek) {
    let price = 0;
    if (typeOfGroup == 'Students') {
        if (dayOfWeek == 'Friday') {
            price = 8.45;
        } else if (dayOfWeek == `Saturday`) {
            price = 9.80;
        } else if (dayOfWeek == `Sunday`) {
            price = 10.46;
        }
    }
    else if (typeOfGroup == `Business`) {
        if (dayOfWeek == 'Friday') {
            price = 10.90;
        } else if (dayOfWeek == `Saturday`) {
            price = 15.60;
        } else if (dayOfWeek == `Sunday`) {
            price = 16;
        }
    } else if (typeOfGroup == `Regular`) {
        if (dayOfWeek == 'Friday') {
            price = 15;
        } else if (dayOfWeek == `Saturday`) {
            price = 20;
        } else if (dayOfWeek == `Sunday`) {
            price = 22.50;
        }
    }

    if (typeOfGroup == `Students` && group >= 30) {
        price -= (price * 0.15);
    }
    else if (typeOfGroup == `Business` && group >= 100) {
        group -= 10;
    }
    else if (typeOfGroup == `Regular` && (group >= 10 && group <= 20)) {
        price -= (price * 0.05);
    }
    
    const totalPrice = price * group;

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

vacationPrice(30, `Students`, `Sunday`);
vacationPrice(40, `Regular`, `Saturday`);