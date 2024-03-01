function split(string){
    let result = string.split(/(?=[A-Z])/);
    console.log(result.join(`, `));
}


split('SplitMeIfYouCanHaHaYouCantOrYouCan');
split('HoldTheDoor');
split('ThisIsSoAnnoyingToDo');