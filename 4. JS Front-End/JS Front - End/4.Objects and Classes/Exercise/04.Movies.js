function solve(array) {
    let movies = [];

    array.forEach(element => {
        if (element.includes('addMovie')) {
            let movie = element.split('addMovie ')[1];
            movies.push({ name: movie });
        } else if (element.includes('directedBy')) {
            let [movieName, director] = element.split(' directedBy ');
            let movie = movies.find(movie => movie.name === movieName);
            if (movie) {
                movie.director = director;
            }
        } else if (element.includes('onDate')) {
            let [movieName, date] = element.split(' onDate ');
            let movie = movies.find(movie => movie.name === movieName);
            if (movie) {
                movie.date = date;
            }
        }
    });

    movies.forEach(movie => {
        if (movie.name && movie.director && movie.date) {
            console.log(JSON.stringify(movie));
        }
    });
}

solve([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
]
);

solve([
    'addMovie The Avengers',
    'addMovie Superman',
    'The Avengers directedBy Anthony Russo',
    'The Avengers onDate 30.07.2010',
    'Captain America onDate 30.07.2010',
    'Captain America directedBy Joe Russo'
    ]
);