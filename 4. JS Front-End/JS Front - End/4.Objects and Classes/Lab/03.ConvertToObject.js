function convert(jsonString){
    let obj = JSON.parse(jsonString);

    for (const element of Object.entries(obj)) {
        const [key, value] = element;
        console.log(`${key}: ${value}`);
    }
}

convert(`{"name": "George", "age": 40, "town": "Sofia"}`);
convert('{"name": "George", "age": 40, "town": "Sofia"}');