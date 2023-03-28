
// Обирається таблиця
const tableSelect = document.getElementById('table-select');

tableSelect.addEventListener('change', (event) => {

    const selectedTable = event.target.value;
  
    console.log(`Selected table: ${selectedTable}`);
  });


// Виводиться таблиця в html вигляді
async function generateTableHtml(url, columnNames){
    const response = await fetch(url);
    const data = await response.json();

    //forming table
    const table = document.createElement('table');

    const headerRow = document.createElement('tr');
    columnNames.forEach(columnName => {
        const headerCell  = document.createElement('th');
        headerCell.textContent = columnName;
        headerRow.appendChild(headerCell);
    });
    table.appendChild(headerRow);

    data.forEach(item => {
        const row = document.createElement('tr');
        Object.values(item).forEach(value => {
            const cell = document.createElement('td');
            cell.textContent = value;
            row.appendChild(cell);
        });
        table.appendChild(row);
    });

    return table.outerHTML;
}


const table1 = ['Код клієнта', 'Назва Клієнта'];
generateTableHtml('/api/Clients', table1).then(html => {
    const container = document.getElementById('table-container');
    container.innerHTML = html;
});