function employees(array) {

    array.forEach(element => {
        const personalNum = element.length;
        console.log(`Name: ${element} -- Personal Number: ${personalNum}`)
    });
}

employees([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
]
);
employees([
    'Samuel Jackson',
    'Will Smith',
    'Bruce Willis',
    'Tom Holland'
]
);