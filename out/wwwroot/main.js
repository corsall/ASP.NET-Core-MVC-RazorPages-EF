const tableSelector = document.getElementById('table-select');

let url; //url for fetch

tableSelector.addEventListener('change', async (event) => {

    const selectedTable = event.target.value;

    url = '/api/' + selectedTable; 


    //clearing form and talbe, to insert new one
    let form = document.getElementById('tableForm');
    while (form.firstChild) {
        form.removeChild(form.firstChild);
    }

    let table = document.querySelector('table');
    while (table.firstChild) {
        table.removeChild(table.firstChild);
    }
    
    await drawTableForm();
    await drawTable();
});


async function drawTable() {
    const response = await fetch(url, {
        method: "GET",
        headers: {"Accept": "application/json"}
    });

    if(response.ok === true){
        const tableContext = await response.json();
        let table = document.querySelector('table');
        let headRows = document.createElement('thead');
        let bodyRows = document.createElement('tbody');

        headRows.append(await getTableTop());

        tableContext.forEach(c => {
            bodyRows.append(row(c));
        });
        table.append(headRows);
        table.append(bodyRows);
    }
}

async function getRow(id) {
    const response = await fetch(url + "/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const row = await response.json();
        const form = document.querySelectorAll('input[id="userInput"]');

        const keys = await getKeys();
        for (let i = 0; i < form.length; i++) {

            if(i == 1) {
                form[i].value = Object.values(row)[0];
                form[i].readOnly = true;
                continue;
            }

            const test = form[i]["name"];
            if(keys.includes(form[i]["name"])) {
                const selector = document.createElement('select');
                selector.setAttribute("id","userInput");

                const options = await getOptions(form[i]["name"]);
                options.forEach(option =>{
                    const optionElement = document.createElement('option');
                    optionElement.text = Object.values(option)[0];
                    optionElement.value = Object.keys(option)[0];

                    selector.appendChild(optionElement);
    
                    form[i].replaceWith(selector);
                });
            }


            if(form[i]["name"] === "id-input") {
                form[i].value = Object.values(row)[0];
                continue;
            }
            form[i].value = row[form[i]["name"]];
        }
    }
}

async function getOptions(key)
{
    const response = await fetch(url+'?$select='+key, {
        method: "GET",
        headers: {"Accept": "application/json"}
    });

    if(response.ok === true){
        const result = await response.json();

        const unique = [];
        const seen = new Set();

        for (const obj of result) {
            const test = obj.value;
            if (!seen.has(Object.values(obj)[0])){
                unique.push(obj);
                seen.add(Object.values(obj)[0]);
            }
        }
        return unique;
    }
}

async function getKeys()
{
    const response = await fetch(url+'/tablekeys', {
        method: "GET",
        headers: {"Accept": "application/json"}
    });

    if(response.ok === true){
        const result = await response.json();
        return result;
    }
}


async function createTableRow(props) {


    const response = await fetch(url, {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(props)
    });
    if(response.ok === true){
        const tableRow = await response.json();
        await resetForm();
        document.querySelector('tbody').append(row(tableRow));
    }
    else {
        alert("Рядок із таким id вже існує");
    }
}

async function editTableRow(id, props){
    const response = await fetch(url + "/" + id, {
        method: "PUT",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(props)
    });
    if (response.ok === true) {
        const tableRow = await response.json();
        await resetForm();
        document.querySelector(`tr[data-rowid='${id}']`).replaceWith(row(tableRow));
    }
}


async function drawTableForm(){
    const response = await fetch(url + '/header', {
        method: "GET",
        headers: {"Accept": "application/json"}
    });

    if(response.ok === true){
        const headers = await response.json();
        let form = document.getElementById('tableForm');

        const inputId = document.createElement("input");
        inputId.setAttribute("id", "userInput");
        inputId.setAttribute("type", "hidden");
        inputId.setAttribute("name", "id-input");
        inputId.setAttribute("value", "0");

        form.append(inputId);

        Object.keys(headers).forEach(header => {
            const label = document.createElement("label");
            label.setAttribute("for", header);
            label.textContent = header + ": ";

            const input = document.createElement("input");
            input.setAttribute("id", "userInput");
            input.setAttribute("name", headers[header]);
            form.append(label);
            form.append(input);
        });

        const buttonSave = document.createElement("button");
        buttonSave.setAttribute("type", "submit");
        buttonSave.textContent = "Save";

        const buttonReset = document.createElement("button");
        buttonReset.setAttribute("id", "reset");
        buttonReset.textContent = "Clear";

        form.append(buttonSave);
        form.append(buttonReset);

        buttonReset.addEventListener("click", e => {
            console.log('reset clicked');
            e.preventDefault();
            resetForm();
        });
    }
}

async function getTableTop(){
    const response = await fetch(url + '/header', {
        method: "GET",
        headers: {"Accept": "application/json"}
    });

    if(response.ok === true){
        const headers = await response.json();

        let headerRow = document.createElement('tr');

        Object.keys(headers).forEach(header => {

            const cell = document.createElement('th');
            cell.textContent = header;
            headerRow.appendChild(cell);
        });

        
        return headerRow;
    }
}

async function deleteTableRow(id) {
    const response = await fetch(url + "/" + id, {
        method: "DELETE",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        document.querySelector(`tr[data-rowid='${id}']`).remove();
    }
}

function row(tableRow){
    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", Object.values(tableRow)[0]);
    for (let key in tableRow){
        const cell = document.createElement('td');
        cell.textContent = tableRow[key];
        tr.appendChild(cell);
    }
    
    const editLink = document.createElement("button");
    editLink.setAttribute("data-id", Object.values(tableRow)[0]);
    editLink.setAttribute("class", "tableBtn");
    editLink.append("Edit");
    editLink.addEventListener("click", e => {
        console.log('btn: change clicked');
        e.preventDefault();
        resetForm();
        getRow(Object.values(tableRow)[0]);
    });
    tr.append(editLink);

    const removeLink = document.createElement("button");
    removeLink.setAttribute("data-id", Object.values(tableRow)[0]);
    removeLink.setAttribute("class", "tableBtn");
    removeLink.append("Delete");
    removeLink.addEventListener("click", e => {
        console.log('btn: delete clicked');
        e.preventDefault();
        deleteTableRow(Object.values(tableRow)[0]);
    });
    tr.append(removeLink);

    return tr;
}

async function resetForm(){
    const form = document.getElementById('tableForm');
    const inputs = form.querySelectorAll("input");

    inputs.forEach(input => {
        input.value = "";
    });
    while (form.children.length > 0) {
        form.children[0].remove();
    }

    await drawTableForm();
}

document.getElementById('tableForm').addEventListener("submit", e => {
    e.preventDefault();
    const userInputElements = document.querySelectorAll('input[id="userInput"]');
    const userSelectorElements = document.querySelectorAll('select[id="userInput"]');
    const userInputs = {};

    userInputElements.forEach((element) => {
        userInputs[element["name"]] = element.value;
    });

    userSelectorElements.forEach((element) => {
        userInputs[element.value] = element.selectedOptions[0].textContent;
    });

    console.log(userInputs);

    const id = document.getElementById('tableForm').elements["id-input"].value;;

    if (id == 0) 
        createTableRow(userInputs);
    else
        editTableRow(id, userInputs);
});

async function getStringTable() {
    const response = await fetch(url, {
        method: "GET",
        headers: {"Accept": "application/json"}
    });

    if(response.ok === true){
        const tableContext = await response.json();
        const stringVersion = {};

        Object.values(tableContext).forEach(row=>{
            stringVersion[Object.values(row)[0]] = (Object.values(row).join(' ').toUpperCase());
        });
        return stringVersion;
    }
}


//TODO: Change regex to something that is more readable and understandable
//Пошукова система Google
async function searchTables(){
    const input = document.getElementById("searchInput");
    regexStrings = input.value.toUpperCase().trim().split(' ');
    //'(?=.*'+item+')'
    const r = regexStrings.map(x => '(?=.*' + x + ')' ).join('') ;

    const searchRegex = new RegExp('^'+ r + '.{0,}' + '$');

    console.log(searchRegex);

    const searchTable = await getStringTable();

    const rowsToDisplay = [];

    Object.keys(searchTable).forEach(value => {
        if (searchRegex.test(searchTable[value])){
            rowsToDisplay.push(value);
        }
    });

    rowsToDisplay.forEach(async rowId => {
        bodyRows = document.querySelector('tbody');
        while (bodyRows.firstChild) {
            bodyRows.removeChild(bodyRows.firstChild);
        }


        const response = await fetch(url + "/"+ rowId, {
            method: "GET",
            headers: {"Accept": "application/json"}
        });
        if(response.ok === true){
            const tableRowContext = await response.json();
            let bodyRows = document.querySelector('tbody');
            bodyRows.append(row(tableRowContext));
        }
    });
}