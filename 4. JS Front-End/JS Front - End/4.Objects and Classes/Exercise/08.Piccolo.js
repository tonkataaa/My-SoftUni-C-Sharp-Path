function parkingLot(info) {
    const parking = {};

    info.forEach(entry => {
        let [direction, carNumber] = entry.split(`, `);

        if (direction == 'IN') {
            parking[carNumber] = direction;
        } else {
            delete parking[carNumber];
        }
        
    });

    if (Object.keys(parking).length === 0) {
        console.log(`Parking Lot is Empty`);
    } else {
        let sortedParking = Object.keys(parking).sort();
        let parkingString = sortedParking.join('\n');
        console.log(parkingString);
       
    }
}

parkingLot(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'IN, CA9999TT',
'IN, CA2866HI',
'OUT, CA1234TA',
'IN, CA2844AA',
'OUT, CA2866HI',
'IN, CA9876HH',
'IN, CA2822UU']
);

parkingLot(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'OUT, CA1234TA']
);