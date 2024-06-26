function solve() {
    const baseUrl = 'http://localhost:3030/jsonstore/bus/schedule/';
    const departButton = document.getElementById('depart');
    const arriveButton = document.getElementById('arrive');
    const infoBox = document.querySelector('#info .info');

    let currentStop = {
        name: 'Depot',
        next: 'depot'
    };

    async function depart() {
        try {
            const response = await fetch(`${baseUrl}${currentStop.next}`);
            const data = await response.json();
            currentStop = data;
            infoBox.textContent = `Next stop ${currentStop.name}`;
            departButton.disabled = true;
            arriveButton.disabled = false;
        } catch (error) {
            infoBox.textContent = 'Error';
            departButton.disabled = true;
            arriveButton.disabled = true;
        }
    }

    function arrive() {
        infoBox.textContent = `Arriving at ${currentStop.name}`;
        departButton.disabled = false;
        arriveButton.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();
