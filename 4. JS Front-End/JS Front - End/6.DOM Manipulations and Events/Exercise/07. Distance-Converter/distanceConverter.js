function attachEventsListeners() {
    const convertButton = document.getElementById("convert");
    convertButton.addEventListener("click", converter);

    function converter() {
        const inputDistance = parseFloat(document.getElementById('inputDistance').value); 
        const inputUnits = document.getElementById('inputUnits').value;
        const outputUnits = document.getElementById('outputUnits').value;
        const outputDistance = document.getElementById('outputDistance');

        let meters = inputDistance * getConversionFactor(inputUnits); // 
        let convertedDistance = meters / getConversionFactor(outputUnits); 
        outputDistance.value = convertedDistance; 
    }

    function getConversionFactor(unit) {
        const conversionRates = {
            km: 1000,
            m: 1,
            cm: 0.01,
            mm: 0.001,
            mi: 1609.34,
            yrd: 0.9144,
            ft: 0.3048,
            in: 0.0254  
        };
        return conversionRates[unit];
    }
}
