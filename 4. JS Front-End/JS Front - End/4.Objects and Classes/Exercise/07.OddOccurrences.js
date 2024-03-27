function solve(sentence) {
    let words = sentence.toLowerCase().split(' ');
    const occurrences = {};

    words.forEach(word => {
        occurrences[word] = (occurrences[word] || 0) + 1;
    });
    let oddOccurrences = Object.keys(occurrences).filter(word => occurrences[word] % 2 !== 0);

    console.log(oddOccurrences.join(' '));
}

solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');