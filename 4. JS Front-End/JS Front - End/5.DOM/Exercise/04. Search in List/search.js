function search() {
   let townsList = Array.from(document.querySelectorAll("li"));
   let text = document.getElementById("searchText").value;
   let result = document.getElementById("result");
   let matches = 0;

   for (const town of townsList) {
      town.style.fontWeight = "";
      town.style.textDecoration = "";   
   }

   for (const town of townsList) {
      if (town.textContent.includes(text)) {
         town.style.fontWeight = "bold";
         town.style.textDecoration = "underline";
         matches++;
      }
      
   }
   result.textContent = `${matches} matches found`;

}
