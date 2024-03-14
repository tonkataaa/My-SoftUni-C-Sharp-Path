function converter(name, lastName, hairColor){
    const obj = {
        name,
        lastName,
        hairColor
    }

    let convertToJson = JSON.stringify(obj);
    console.log(convertToJson);
}

converter('George', 'Jones', 'Brown');
converter('Peter', 'Smith', 'Blond');