function attachEvents() {
    const baseUrl = 'http://localhost:3030/jsonstore/forecaster';

    const locationElement = document.getElementById('location');
    const submitButton = document.getElementById('submit');
    const forecastElement = document.getElementById('forecast');
    const currentElement = document.getElementById('current');
    const upcomingElement = document.getElementById('upcoming');

    const weatherSymbol = {
        'Sunny': '☀',
        'Partly sunny': '⛅',
        'Overcast': '☁',
        'Rain': '☂',
        'Degrees': '°',
    };

    submitButton.addEventListener('click', () => {
        fetch(`${baseUrl}/locations`)
            .then(res => res.json())
            .then(locationData => {
                const location = locationData.find(loc => loc.name.toLowerCase() === locationElement.value.toLowerCase());

                if (!location) {
                    throw new Error('Location not found');
                }

                return Promise.all([
                    fetch(`${baseUrl}/today/${location.code}`),
                    fetch(`${baseUrl}/upcoming/${location.code}`)
                ]);
            })
            .then(responses => Promise.all(responses.map(res => res.json())))
            .then(([today, upcoming]) => {
                displayCurrentCondition(today);
                displayUpcomingConditions(upcoming);
                forecastElement.style.display = 'block';
            })
            .catch(error => {
                forecastElement.style.display = 'block';
                forecastElement.textContent = 'Error';
            });
    });

    function displayCurrentCondition(today) {
        currentElement.innerHTML = ''; 

        const forecastsElement = document.createElement('div');
        forecastsElement.classList.add('forecasts');

        const symbolSpan = document.createElement('span');
        symbolSpan.classList.add('condition', 'symbol');
        symbolSpan.textContent = weatherSymbol[today.forecast.condition];

        const conditionSpan = document.createElement('span');
        conditionSpan.classList.add('condition');

        const locationNameSpan = document.createElement('span');
        locationNameSpan.classList.add('forecast-data');
        locationNameSpan.textContent = today.name;

        const temperatureSpan = document.createElement('span');
        temperatureSpan.classList.add('forecast-data');
        temperatureSpan.textContent = `${today.forecast.low}°/${today.forecast.high}°`;

        const conditionTextSpan = document.createElement('span');
        conditionTextSpan.classList.add('forecast-data');
        conditionTextSpan.textContent = today.forecast.condition;

        conditionSpan.append(locationNameSpan, temperatureSpan, conditionTextSpan);
        forecastsElement.append(symbolSpan, conditionSpan);
        currentElement.appendChild(forecastsElement);
    }

    function displayUpcomingConditions(upcoming) {
        upcomingElement.innerHTML = ''; 

        const forecastInfoDiv = document.createElement('div');
        forecastInfoDiv.classList.add('forecast-info');

        upcoming.forecast.forEach(day => {
            forecastInfoDiv.appendChild(displayUpcomingDay(day));
        });

        upcomingElement.appendChild(forecastInfoDiv);
    }

    function displayUpcomingDay(day) {
        const upcomingSpan = document.createElement('span');
        upcomingSpan.classList.add('upcoming');

        const symbolSpan = document.createElement('span');
        symbolSpan.classList.add('symbol');
        symbolSpan.textContent = weatherSymbol[day.condition];

        const temperatureSpan = document.createElement('span');
        temperatureSpan.classList.add('forecast-data');
        temperatureSpan.textContent = `${day.low}°/${day.high}°`;

        const conditionSpan = document.createElement('span');
        conditionSpan.classList.add('forecast-data');
        conditionSpan.textContent = day.condition;

        upcomingSpan.append(symbolSpan, temperatureSpan, conditionSpan);

        return upcomingSpan;
    }
}

attachEvents();
