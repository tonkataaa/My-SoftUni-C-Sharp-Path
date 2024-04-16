function addItem() {
    let itemsList = document.getElementById('items');
    let input = document.getElementById("newItemText").value;

    let inputLi = document.createElement("li");
    inputLi.textContent = input;

    itemsList.appendChild(inputLi);
}