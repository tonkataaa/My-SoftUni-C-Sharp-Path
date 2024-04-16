function solve() {
    let selectMenuTo = document.getElementById("selectMenuTo");
    let result = document.getElementById("result");
    
    //Binary option
  const optionBinary = document.createElement("option");
  optionBinary.value = "binary";
  optionBinary.text = "Binary";
  selectMenuTo.appendChild(optionBinary);
  
  //Hexadecimal option
  const optionHexaDecimal = document.createElement("option");
  optionHexaDecimal.value = "hexadecimal";
  optionHexaDecimal.text = "Hexadecimal";
  selectMenuTo.appendChild(optionHexaDecimal);
  
  document.querySelector('button').addEventListener('click', function(){
      let inputNumber = document.getElementById("input").value;
      let selectedOption = selectMenuTo.value;

      if (selectedOption === "hexaDdcimal") {
        let numberConverter = Number(inputNumber);
        let hex = numberConverter.toString(16);
        hex = hex.padStart(2, "0").toUpperCase();
        result.value = hex;
      } else if (selectedOption === "binary") {
        let number = Number(inputNumber);
        let binaryString = number.toString(2);
        result.value = binaryString;
      }
  })
}
