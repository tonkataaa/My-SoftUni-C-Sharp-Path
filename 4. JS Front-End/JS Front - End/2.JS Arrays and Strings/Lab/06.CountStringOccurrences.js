function solve(text, wordForSearch){
    let regex = new RegExp("\\b" + wordForSearch + "\\b", "g");
    let matches = text.match(regex);
    let count = matches ? matches.length : 0;
    console.log(count);
}


solve('This is a word and it also is a sentence', 'is');
solve('softuni is great place for learning new programming languages', 'softuni');