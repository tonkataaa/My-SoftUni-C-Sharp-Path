function phoneBook(array){
    const phoneBook = {};

    array.forEach(function(entry) {
        let [name, number] = entry.split(' ');

        if (phoneBook.hasOwnProperty(name)) {
            phoneBook[name] = number;
        } else {
            phoneBook[name] = number;
        }
    });

    for (const name in phoneBook) {
        console.log(`${name} -> ${phoneBook[name]}`);
        
    }
}

phoneBook(['Tim 0834212554',
'Peter 0877547887',
'Bill 0896543112',
'Tim 0876566344']
);

phoneBook(['George 0552554',
'Peter 087587',
'George 0453112',
'Bill 0845344']
);