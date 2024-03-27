function colorize() {
    const tableRows = document.getElementsByTagName('tr');
    for (let index = 0; index < tableRows.length; index++) {
        if (index % 2 != 0) {
            tableRows[index].style.background = "teal";
        }    
    }
}