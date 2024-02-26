function isItLeap(year) {
    if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) {
        console.log('yes');
    }else{
        console.log('no');
    }
}

isItLeap(1984);
isItLeap(2003);
isItLeap(4);