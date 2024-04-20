function solve() {
    document.addEventListener('DOMContentLoaded', function () {
        const quickCheckButton = document.querySelector('tfoot button:first-child');
        const clearButton = document.querySelector('tfoot button:last-child');
        const table = document.querySelector('table');
        const messageParagraph = document.getElementById('check').querySelector('p');

        quickCheckButton.addEventListener("click", function () {
            const inputs = Array.from(document.querySelectorAll('tbody input[type="number"]'));
            if (checkSudoku(inputs.map(input => parseInt(input.value || 0)))) {
                table.style.border = '2px solid green';
                messageParagraph.textContent = "You solve it! Congratulations!";
                messageParagraph.style.color = 'green';
            } else {
                table.style.border = '2px solid red';
                messageParagraph.textContent = "NOP! You are not done yet...";
                messageParagraph.style.color = 'red';
            }
        });

        clearButton.addEventListener('click', function () {
            document.querySelectorAll('tbody input[type="number"]').forEach(input => input.value = '');
            messageParagraph.textContent = '';
            table.style.border = '';
        });

    })

    function checkSudoku(values) {
        return values.length === 9 && new Set(values).size === 9 && values.reduce((a, b) => a + b, 0) === 45;
    }
}