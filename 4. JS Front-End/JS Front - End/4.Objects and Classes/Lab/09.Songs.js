function solve(array) {
    let songs = [];
    let songsCount = array.shift(); // count
    let printType = array.pop(); // keyword or all

    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    for (let index = 0; index < songsCount; index++) {
        const songInfo = array[index].split('_');
        const [typeList, name, time] = songInfo;
        const song = new Song(typeList, name, time);
        songs.push(song);
    }

    if (printType == "all") {
        songs.forEach((element) => console.log(element.name));
    } else {
        songs.filter((song) => song.typeList == printType)
            .forEach((element) => console.log(element.name));

    }
}

solve([3,
    'favourite_DownTown_3:14',
    'favourite_Kiss_4:16',
    'favourite_Smooth Criminal_4:01',
    'favourite']
);

solve([4,
    'favourite_DownTown_3:14',
    'listenLater_Andalouse_3:24',
    'favourite_In To The Night_3:58',
    'favourite_Live It Up_3:48',
    'listenLater']
);

solve([2,
    'like_Replay_3:15',
    'ban_Photoshop_3:48',
    'all']
);