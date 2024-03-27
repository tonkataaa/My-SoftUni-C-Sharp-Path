function editElement(ref, match, replacer) {
   const content = ref.textContent; //take the text
   const editedText = content.replace(new RegExp(match, 'g'), replacer); // edit it 
   ref.textContent = editedText; // put it back
}