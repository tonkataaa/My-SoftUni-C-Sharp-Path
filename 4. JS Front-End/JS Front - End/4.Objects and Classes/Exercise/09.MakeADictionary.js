function dictionaryMaker(jsonArray) {
    let dictionary = {};

   jsonArray.forEach(jsonString => {
    let obj = JSON.parse(jsonString);
    for (const term in obj) {
        dictionary[term] = obj[term];
    }
   });

   const sortedDictionary = Object.keys(dictionary).sort().reduce(
    (obj, key) => {
        obj[key] = dictionary[key];
        return obj;
    },
    {}
    )

    for (const term in sortedDictionary) {
        console.log(`Term: ${term} => Definition: ${sortedDictionary[term]}`);
    }
}

dictionaryMaker([
    '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
]);