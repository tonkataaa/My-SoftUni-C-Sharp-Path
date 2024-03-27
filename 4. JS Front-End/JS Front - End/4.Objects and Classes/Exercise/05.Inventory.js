function heroGenerator(array) {
    let heroes = [];

    array.forEach(element => {
        let [name, level, items] = element.split(` / `);
        let item = items ? items.split(`, `) : [];
        level = Number(level);
        heroes.push({ name, level, items });
    });

    heroes.sort((a, b) => a.level - b.level);

    heroes.forEach(hero => {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`Items => ${hero.items}`);
    })
}

heroGenerator([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
]
);