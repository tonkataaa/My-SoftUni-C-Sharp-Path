function solve(array) {

    let cats = [];

    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }

        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }


    for (let index = 0; index < array.length; index++) {
        const catInfo = array[index].split(' ');
        const [name, age] = catInfo;
        const cat = new Cat(name, age);
        cat.meow();
        cats.push(cat);    
    }
}

solve(['Mellow 2', 'Tom 5']);
solve(['Candy 1', 'Poppy 3', 'Nyx 2']);