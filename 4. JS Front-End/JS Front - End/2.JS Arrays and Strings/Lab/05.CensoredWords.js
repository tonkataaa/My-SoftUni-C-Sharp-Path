function solve(text, wordToCensor){
    let wordLength = wordToCensor.length;
    let result = text.replace(new RegExp(wordToCensor,"g"), "*".repeat(wordLength));
    console.log(result);
}


solve('A small sentence with some words', 'small');
solve('Find the hidden word', 'hidden');