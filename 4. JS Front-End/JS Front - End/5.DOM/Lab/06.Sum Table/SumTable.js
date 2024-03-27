function sumTable() {
    let digits = document.getElementsByTagName("td");
    let sum = 0;
    
    for (let index = 0; index < digits.length; index++) {
        let price = digits[index].textContent.trim();
        let priceAsNum = Number(price);
        if (!isNaN(priceAsNum)) { // Check if the parse is successfull
            sum += priceAsNum;
        }
    }
    let sumText = document.getElementById("sum");
    sumText.textContent = sum;
}