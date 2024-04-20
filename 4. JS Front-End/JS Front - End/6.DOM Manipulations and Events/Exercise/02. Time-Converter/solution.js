function attachEventsListeners() {
    let daysInput = document.getElementById("days");
    let hoursInput = document.getElementById("hours");
    let minutesInput = document.getElementById("minutes");
    let secondsInput = document.getElementById("seconds");
    
    let daysButton = document.getElementById("daysBtn");
    daysButton.addEventListener("click", daysConvert);
    
    let hoursButton = document.getElementById("hoursBtn");
    hoursButton.addEventListener("click", hoursConvert);
    
    let minutesButton = document.getElementById("minutesBtn");
    minutesButton.addEventListener("click", minutesConvert);
    
    let secondsButton = document.getElementById("secondsBtn");
    secondsButton.addEventListener("click", secondsConvert);
    
    function daysConvert() {
        let day = Number(daysInput.value);  
        hoursInput.value = day * 24;    
        minutesInput.value = day * 1440;  
        secondsInput.value = day * 86400;  
    }
    

    function hoursConvert(){
        let hours = Number(hoursInput.value);
        daysInput.value = hours / 24;
        minutesInput.value = hours * 60;
        secondsInput.value = hours * 3600;
    }

    function minutesConvert() {
        let minutes = Number(minutesInput.value);
        daysInput.value = Math.floor(minutes / 1440);
        hoursInput.value = minutes / 60;
        secondsInput.value = minutes * 60;
    }

    function secondsConvert() {
        let seconds = Number(secondsInput.value);
        daysInput.value = Math.floor(seconds / 86400);
        hoursInput.value = seconds / 3600;
        minutesInput.value = seconds / 60;
    }

}