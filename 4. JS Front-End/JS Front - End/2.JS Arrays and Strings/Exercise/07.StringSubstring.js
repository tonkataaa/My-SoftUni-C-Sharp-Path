function substring(lookForWord, text) {
    let result = text.toLowerCase();
    if (result.includes(lookForWord)) {
        console.log(lookForWord);
    } else {
        console.log(`${lookForWord} not found!`);
    }
}

substring('javascript',`JavaScript is the best programming language'`);
substring('python','JavaScript is the best programming language');

