function solve() {
  const buttons = document.querySelectorAll("button");
  const generateButton = buttons[0];
  const buyButton = buttons[0];

  generateButton.addEventListener("click", generate);
  buyButton.addEventListener("click", buy);

  function generate() {
    let inputText = document.querySelector('#exercise textarea').value;
    let tableBody = document.querySelector('.table tbody');

    tableBody.innerHTML = '';
    const furnitureArray = JSON.parse(inputText);
    furnitureArray.forEach(item => {
      const row = document.createElement('tr');
      row.innerHTML = `
          <td><img src="${item.img}" style="width:100px;height:auto;"></td>
          <td><p>${item.name}</p></td>
          <td><p>${item.price}</p></td>
          <td><p>${item.decFactor}</p></td>
          <td><input type="checkbox"></td>
        `;
        tableBody.appendChild(row);     
    });
  }

  function buy() {
    const checkboxes = document.querySelectorAll('.table tbody input[type="checkbox"]');
    let names = [];
    let totalCost = 0;
    let totalDecFactor = 0;
    let count = 0;

    checkboxes.forEach((checkbox, index) => {
      if (checkbox.checked) {
        const row = checkbox.closest('tr');
        names.push(row.cells[1].textContent.trim());
        totalCost += parseFloat(row.cells[2].textContent);
        totalDecFactor += parseFloat(row.cells[3].textContent);
        count++;
      }
      let averageDecFactor = count > 0 ? totalDecFactor / count : 0;
      let resultText = `Bought furniture: ${names.join(", ")}\nTotal price: ${totalCost.toFixed(2)}\nAverage decoration factor: ${averageDecFactor.toFixed(2)}`;
      document.querySelectorAll('#exercise textarea')[1].value = resultText; 
    });
  }
}
