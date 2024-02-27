function solve(array) {
    let evenArray = array.filter(n => n % 2 == 0).reduce((accumulator, currentValue) => accumulator + currentValue, 0);
    let oddArray = array.filter((n) => n % 2 != 0).reduce((accumulator, currentValue) => accumulator + currentValue, 0);
    const difference = evenArray - oddArray;

    console.log(difference);
}

solve([1, 2, 3, 4, 5, 6]);
solve([3, 5, 7, 9]);
solve([2, 4, 6, 8, 10]);