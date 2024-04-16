function focused() {
  let divs = Array.from(document.querySelectorAll("input[type=text]"));

  function addFocus(e) {
    e.target.parentNode.classList.add("focused");
  }

  function removeFocus(e) {
    e.target.parentNode.classList.remove("focused");
  }

  divs.forEach((div) => {
    div.addEventListener("focus", addFocus);
    div.addEventListener("blur", removeFocus);
  });
}
