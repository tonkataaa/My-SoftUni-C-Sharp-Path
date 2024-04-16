function deleteByEmail() {
  const input = document.querySelector("input[name='email']").value;
  let table = document.getElementById("customers");
  let result = document.getElementById("result");

  let tbody = table.getElementsByTagName("tbody")[0];
  let rows = tbody.getElementsByTagName("tr");

  let isFound = false;
  for (let i = 0; i < rows.length; i++) {
    let cells = rows[i].getElementsByTagName("td");
    for (let j = 0; j < cells.length; j++) {
      if (cells[j].textContent === input) {
        tbody.removeChild(rows[i]);
        result.textContent = "Deleted";
        isFound = true;
        break;
      }
    }
    if (isFound) {
      break;
    }
  }

  if (!isFound) {
    result.textContent = "Not found.";
  }
}
