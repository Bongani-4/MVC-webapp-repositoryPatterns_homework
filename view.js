const input = document.getElementById("file-input");
const table = document.getElementById("excel-table");

input.addEventListener('change', (event) => {
    const file = event.target.files[0];

    readXlsxFile(file).then((rows) => {
        console.log(rows);
        table.innerHTML = "";

        rows.forEach((row) => {
            let tr = document.createElement('tr');
            row.forEach((cell) => {
                const td = document.createElement('td');
                td.textContent = cell;
                tr.appendChild(td);

                // Check if the current cell is a date and apply color class
                if (isDate(cell)) {
                    const currentDate = new Date();
                    const dueDate = new Date(cell);
                    const daysRemaining = Math.floor((dueDate - currentDate) / (1000 * 60 * 60 * 24));

                    if (daysRemaining > 5) {
                        tr.classList.add('green');
                    } else if (daysRemaining >= 3 && daysRemaining <= 5) {
                        tr.classList.add('yellow');
                    } else if (daysRemaining < 3) {
                        tr.classList.add('red');
                    }
                }
            });
            table.appendChild(tr);
        });
    });
});

// Function to check if a value is a date
function isDate(value) {
    return (new Date(value) !== "Invalid Date" && !isNaN(new Date(value)));
}
