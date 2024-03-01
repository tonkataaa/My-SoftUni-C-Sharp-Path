function solve(text) {
    let words = text.match(/#[A-Za-z]+/gm);

    for (let word of words) {
        console.log(word.replace(`#`, ``));
    }
}

solve('Nowadays everyone uses # to tag a #special word in #socialMedia');
solve('The symbol # is known #variously in English-speaking #regions as the #number sign');