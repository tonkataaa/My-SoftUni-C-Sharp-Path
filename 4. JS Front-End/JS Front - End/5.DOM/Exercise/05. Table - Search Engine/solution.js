function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const rows = document.querySelectorAll('table.container tbody tr'); //get the rows with names, email and courses
      rows.forEach(row => row.classList.remove('select'));

      const searchValue = document.getElementById('searchField').value.toLowerCase();

      if (searchValue.trim() !== '') {
         for (const row of rows) { //literate trough rows
            const cells = row.getElementsByTagName('td'); // get the cells
            let rowContainsSearchValue = false;

            for (const cell of cells) { // litreate trough the cells
               if (cell.textContent.toLocaleLowerCase().includes(searchValue)) {
                  rowContainsSearchValue = true;
                  row.style.backgroundColor = 'yellow';
               }

               if (rowContainsSearchValue) {
                  row.classList.add('select');
               }
            }
         }
      } else {
         for (const row of rows) {
            row.style.backgroundColor = '';
         }
      }
      document.getElementById('searchField').value = '';

   }
}