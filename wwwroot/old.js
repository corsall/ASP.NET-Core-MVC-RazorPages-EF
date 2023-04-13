const container = document.getElementById('table-container');
// Обирається таблиця
const tableSelect = document.getElementById('table-select');

let url;

tableSelect.addEventListener('change', async (event) => {

    const selectedTable = event.target.value;

    url = '/api/' + selectedTable;
    
    // await drawTable(`/api/${selectedTable}`);
    await drawTable(url);

    initDeleteButtons(selectedTable);
    initUpdateButtons(selectedTable);

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

        cell.appendChild(createDeleteButton(Object.values(item)[0]));
        cell.appendChild(createUpdateButton(Object.values(item)[0]));
        row.appendChild(cell);
        table.appendChild(row);
    });
    container.innerHTML = table.outerHTML;
}

function createDeleteButton(id){
    const deleteButton = document.createElement('button');
    deleteButton.id = "delete";
    deleteButton.setAttribute('data-id', id);
    deleteButton.textContent = 'Delete';
    return deleteButton;
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
            await deleteRow(id);
        });
    });
}

async function deleteRow(id)
{
    const response = await fetch(`${url}/${id}`, 
    {
        method: 'DELETE',
    })
    if(response.ok === true)
    {
        await drawTable(url);
    }
}

function createUpdateButton(id){
    const updateButton = document.createElement('button');
    updateButton.id = "update";
    updateButton.setAttribute('data-id', id);
    updateButton.textContent = 'Update';
    return updateButton;
}

function initUpdateButtons(selectedTable){
    const updateButtons = document.querySelectorAll('#update');

    updateButtons.forEach((button) => {
        button.addEventListener('click', async () => {
            const id = button.dataset.id;

            console.log(`Update button clicked for item ${id}`);
            await editTable(url, id);
            initPostButton(id);
        });
    });
}

async function updateRow(id)
{
    const response = await fetch(`${url}/${id}`, 
    {
        method: 'Up',
    })
    if(response.ok === true)
    {
        await editTable()
    }
}

async function editTable(url, id){
    const response = await fetch(url + `/${id}`);
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
    table.appendChild(headerRow);

    //вивід
    const row = document.createElement('tr');
    const keys = await getKeys(url);
    for(const value in data)
    {
        const cell = document.createElement('td');
        if(keys.includes(value))
        {
            const selector = document.createElement('select');
            //TODO:
            const options = await getOptions(url, value);
            options.forEach(option =>{
                const optionElement = document.createElement('option');
                optionElement.text = Object.values(option)[0];
                optionElement.value = Object.keys(option)[0];;

                selector.appendChild(optionElement);
            });
            
            cell.appendChild(selector);
        }
        else{
            cell.textContent = data[value];
        }

        row.appendChild(cell);
    }
    const updateCell = document.createElement('td');
    updateCell.appendChild(createUpdateButton(id));
    row.appendChild(updateCell);

    table.appendChild(row);

    container.innerHTML = table.outerHTML;
}

async function getOptions(url,key)
{
    const response = await fetch(url+'?$select='+key);
    return await response.json();
}

function initPostButton(id){
    const postButton = document.querySelectorAll('#update');

    postButton.forEach((button) => {
        button.addEventListener('click', async () => {
            console.log(`Post button clicked for item ${id}`);
            await updateRow(id);
        });
    });
}


async function getOptions(url,key)
{
    const response = await fetch(url+'?$select='+key);
    return await response.json();
}


async function getKeys(url)
{
    const response = await fetch(url+'/tablekeys');
    return await response.json();
}

async function updateRow(id)
{
    const rowInfo = document.querySelector("table").rows[1].cells;

    var data = {};

    for (let i = 0; i < rowInfo.length; i++) {
        if(rowInfo[i].children[0] !== undefined)
        {
            let option = rowInfo[i].children[0].selectedOptions[0];

            let key = option.value;
            let value = option.text;

            data[key] = value;
        }
        else{
            data[rowInfo[i]] = rowInfo[i].textContent;
        }
    }


    const response = await fetch(`${url}/${id}`,{
        method: 'PUT',
        body: JSON.stringify(data)
    })
    if(response.ok === true)
    {
        await drawTable(url);
    }
}