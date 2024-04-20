function create(words) {
   const divs = document.getElementById("content");

   words.forEach(word => {
      let div = document.createElement("div");
      let paragraph = document.createElement("p");
      paragraph.textContent = word;
      paragraph.style.display = "none";
      div.addEventListener("click", onclick);
      div.appendChild(paragraph);
      divs.appendChild(div);

      function onclick(e) {
         paragraph.style.display = paragraph.style.display === "block" ? "none" : "block";
      } 
   });
}