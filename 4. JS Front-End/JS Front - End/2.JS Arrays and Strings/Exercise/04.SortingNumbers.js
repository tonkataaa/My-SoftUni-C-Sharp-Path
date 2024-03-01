function customSort(array) {
    let sortedArray = array.slice().sort((a, b) => a - b); 

    let resultArray = [];
    for (let i = 0; i < array.length; i++) {
        if (i % 2 === 0) {
            resultArray.push(sortedArray.shift()); 
        } else {
            resultArray.push(sortedArray.pop()); 
        }
    }
    return resultArray;
}

sort([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);
