function generateReport() {
    const table = document.querySelector('table');  
    const output = document.getElementById('output'); 
    const headers = Array.from(table.querySelectorAll('thead th'));
    const rows = Array.from(table.querySelectorAll('tbody tr')); 
    const report = []; 

    const columns = [];
    headers.forEach((header, index) => {
        const checkbox = header.querySelector('input[type="checkbox"]');
        if (checkbox && checkbox.checked) {
            columns.push({
                index: index,
                name: checkbox.name
            });
        }
    });

    rows.forEach(row => {
        const cells = Array.from(row.querySelectorAll('td')); 
        const record = {};
        columns.forEach(col => {
            const cellText = cells[col.index].textContent.trim(); 
            record[col.name] = cellText; 
        });
        report.push(record); 
    });

    output.value = JSON.stringify(report, null, 2); 
}
