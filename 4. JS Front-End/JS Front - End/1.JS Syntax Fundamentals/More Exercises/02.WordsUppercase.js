function solve(text) {
    let result = text.toUpperCase()
      .match(/[a-zA-Z0-9]+/g)
      .filter((w) => w.length >= 1)
      .join(", ");
  
    console.log(text);
  }

solve('Hi, how are you?');
solve('hello');