function meetings(array){
    const meetingsSchedule = {};

    array.forEach(function(entry) {
        let [day, name] = entry.split(' ');

        if (!meetingsSchedule.hasOwnProperty(day)) {
            console.log(`Scheduled for ${day}`);
            meetingsSchedule[day] = name;
        } else {
            console.log(`Conflict on ${day}!`);
        }
    });

    for (const key in meetingsSchedule) {
        console.log(`${key} -> ${meetingsSchedule[key]}`);
    }
}

meetings(['Monday Peter',
'Wednesday Bill',
'Monday Tim',
'Friday Tim']
);

meetings(['Friday Bob',
'Saturday Ted',
'Monday Bill',
'Monday John',
'Wednesday George']
);