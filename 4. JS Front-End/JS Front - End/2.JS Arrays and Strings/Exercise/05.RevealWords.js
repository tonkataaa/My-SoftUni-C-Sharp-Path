function reveal(words, text) {
    let wordsArray = words.split(`, `);
    let textArray = text.split(` `);

    for (let i = 0; i < wordsArray.length; i++) {
        for (let j = 0; j < textArray.length; j++) {
            if (wordsArray[i].length == textArray[j].length && textArray[j].includes(`*`)) {
                textArray[j] = wordsArray[i];
            }
        }
    }
    console.log(textArray.join(` `));
}

reveal('great',
'softuni is ***** place for learning new programming languages'
);

reveal('great, learning',
'softuni is ***** place for ******** new programming languages'
);