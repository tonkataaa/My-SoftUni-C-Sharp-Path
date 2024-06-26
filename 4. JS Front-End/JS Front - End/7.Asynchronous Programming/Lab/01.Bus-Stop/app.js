function getInfo() {
    const baseUrl = 'http://localhost:3030/jsonstore/bus/businfo';

    const stopId = document.getElementById('stopId');
    const stopNameElement = document.getElementById('stopName');
    const busesListElement = document.getElementById('buses');
    
    busesListElement.innerHTML = '';

    fetch(baseUrl + `/${stopId.value}`)
    .then((res) => res.json())
    .then((data) => {
        stopNameElement.textContent = data.name;
        let numberOfBuses = Object.keys(data.buses).length;
        let newLi = document.createElement('li');

        for (const [key, value] of Object.entries(data.buses)) {
            let newLi = document.createElement('li');
            newLi.textContent = `Bus ${key} arrives in ${value} minutes`;
            busesListElement.appendChild(newLi);       
        }
    })
    .catch((error) => stopNameElement.textContent = 'Error');
}
    