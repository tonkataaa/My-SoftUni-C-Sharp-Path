function addresses(array){
    let addressBook = {};

    array.forEach(function(entry) {
        let [name, address] = entry.split(`:`);

        if (!addressBook.hasOwnProperty(name)) {
            addressBook[name] = address;
        } else {
            addressBook[name] = address;
        }
    });

    let sortedKeys = Object.keys(addressBook).sort();

    for (const key of sortedKeys) {
        console.log(`${key} -> ${addressBook[key]}`);
    }
}

addresses(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']
);

addresses(['Bob:Huxley Rd',
'John:Milwaukee Crossing',
'Peter:Fordem Ave',
'Bob:Redwing Ave',
'George:Mesta Crossing',
'Ted:Gateway Way',
'Bill:Gateway Way',
'John:Grover Rd',
'Peter:Huxley Rd',
'Jeff:Gateway Way',
'Jeff:Huxley Rd']
);

