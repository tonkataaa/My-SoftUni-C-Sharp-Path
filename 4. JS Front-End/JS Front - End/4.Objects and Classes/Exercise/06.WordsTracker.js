function solve(text) {
    let occurrences = {};
    const [wordsToSearch, ...sentences] = text;
    

    sentences.forEach(sentence => {
        let words = sentence.split(' ');
        words.forEach(word => {
            if (wordsToSearch.includes(word)) {
                if (!occurrences[word]) {
                    occurrences[word] = 1;
                } else {
                    occurrences[word]++;
                }
            }
        })
    });

    const wordOccurrences = Object.entries(occurrences).map(([word, count]) => ({ word, count }));
    wordOccurrences.sort((a, b) => b.count - a.count);

    wordOccurrences.forEach(({word, count}) => {
        console.log(`${word} - ${count}`);
    })
}

solve([
    'this sentence',
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
]
);

solve([
'is the', 
'first', 'sentence', 'Here', 'is', 'another', 'the', 'And', 'finally', 'the', 'the', 'sentence']
)
