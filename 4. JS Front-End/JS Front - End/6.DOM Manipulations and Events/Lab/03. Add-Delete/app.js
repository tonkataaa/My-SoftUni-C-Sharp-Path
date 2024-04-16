function addItem() {
  let itemsList = document.getElementById("items");
  let input = document.getElementById("newItemText").value;

  let inputLi = document.createElement("li");
  let deleteLink = document.createElement("a");

  inputLi.textContent = input;

  deleteLink.href = "#";
  deleteLink.textContent = "[Delete]";

  deleteLink.addEventListener("click", function () {
    inputLi.remove();
  });
  inputLi.appendChild(deleteLink);
  itemsList.appendChild(inputLi);
}
