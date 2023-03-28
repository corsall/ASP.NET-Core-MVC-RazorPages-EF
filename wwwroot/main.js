const container = document.getElementById('table-container');
// Обирається таблиця
const tableSelect = document.getElementById('table-select');

tableSelect.addEventListener('change', async (event) => {

    const selectedTable = event.target.value;
    
    await drawTable(`/api/${selectedTable}`);

    initDeleteButtons(selectedTable);

    // await drawTable(`/api/${selectedTable}`).then(html => {
    //     const container = document.getElementById('table-container');
    //     container.innerHTML = html;
    // });
});


// Виводиться таблиця в html вигляді
async function drawTable(url){
    const response = await fetch(url);
    let data;
    if(response.ok === true)
    {
        data = await response.json();
    }

    //forming table
    const table = document.createElement('table');

    const headerRow = document.createElement('tr');

    columnNames = await getTableHeader(url);
    columnNames.forEach(columnName => {
        const headerCell  = document.createElement('th');
        headerCell.textContent = columnName;
        headerRow.appendChild(headerCell);
    });
    const emptyHeaderCell  = document.createElement('th');
    headerRow.appendChild(emptyHeaderCell);
    table.appendChild(headerRow);

    data.forEach(item => {
        const row = document.createElement('tr');
        Object.values(item).forEach(value => {
            const cell = document.createElement('td');
            cell.textContent = value;
            row.appendChild(cell);
        });

        const cell = document.createElement('td');
        const deleteButton = document.createElement('button');
        deleteButton.id = "delete";
        deleteButton.setAttribute('data-id', Object.values(item)[0]);
        deleteButton.textContent = 'Delete';

        cell.appendChild(deleteButton);
        row.appendChild(cell);
        table.appendChild(row);
    });
    container.innerHTML = table.outerHTML;
}

async function getTableHeader(url)
{
    const response = await fetch(url+'/header');
    return await response.json();
}

function initDeleteButtons(selectedTable){
    const deleteButtons = document.querySelectorAll('#delete');

    deleteButtons.forEach((button) => {
        button.addEventListener('click', async () => {
            const id = button.dataset.id;

            console.log(`Delete button clicked for item ${id}`);
            await deleteRow(selectedTable, id);
        });
    });
}

async function deleteRow(table, id)
{
    const response = await fetch(`/api/${table}/${id}`, 
    {
        method: 'DELETE',
    })
    if(response.ok === true)
    {
        await drawTable(`/api/${table}`);
    }
}
