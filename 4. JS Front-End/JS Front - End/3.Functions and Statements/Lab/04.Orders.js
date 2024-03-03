function calculateTotalPrice(product, quantity) {
    function getProductPrice(product) {
        switch (product) {
            case 'coffee':
                return 1.50;
            case 'water':
                return 1.00;
            case 'coke':
                return 1.40;
            case 'snacks':
                return 2.00;
        }
    }
    let totalPrice = getProductPrice(product) * quantity;
    console.log(`${totalPrice.toFixed(2)}`);
}

calculateTotalPrice(`water`, 5);
calculateTotalPrice(`coffee`, 2);