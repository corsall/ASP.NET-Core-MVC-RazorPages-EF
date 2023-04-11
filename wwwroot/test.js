const tableSelector = document.getElementById('table-select');


let url;

tableSelector.addEventListener('change', async (event) => {

    const selectedTable = event.target.value;

    url = '/api/' + selectedTable; // changing global url 


    //clearing form and talbe, to insert new one
    let form = document.getElementById('tableForm');
    while (form.firstChild) {
        form.removeChild(form.firstChild);
    }

    let table = document.querySelector('table');
    while (table.firstChild) {
        table.removeChild(table.firstChild);
    }
    

    await getTable();
    await getTableForm();
});




async function getTable() {
    const response = await fetch(url, {
        method: "GET",
        headers: {"Accept": "application/json"}
    });

    if(response.ok === true){
        const tableContext = await response.json();
        let table = document.querySelector('table');
        let rows = document.createElement('tbody');

        tableContext.forEach(c => {
            rows.append(row(c));
        });
        table.append(rows);
    }
}
//TODO:
async function getRow(id) {
    const response = await fetch(url + "/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const row = await response.json();
        const form = document.querySelectorAll('input');

        for (let i = 0; i < form.length; i++) {
            const aga = form[i];
            if(form[i]["name"] === "id-input") {
                form[i].value = Object.values(row)[0];
                continue;
            }
            form[i].value = row[form[i]["name"]];
        }
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
        resetForm(); //TODO:
        document.querySelector('tbody').append(row(tableRow));
    }
}


async function getTableForm(){
    const response = await fetch(url + '/header', {
        method: "GET",
        headers: {"Accept": "application/json"}
    });

    if(response.ok === true){
        const headers = await response.json();
        let form = document.getElementById('tableForm');

        const inputId = document.createElement("input");
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
        buttonReset.setAttribute("type", "reset");
        buttonReset.textContent = "Clear";

        form.append(buttonSave);
        form.append(buttonReset);
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
    editLink.append("Edit");
    editLink.addEventListener("click", e => {
        console.log('btn: change clicked');
        e.preventDefault();
        getRow(Object.values(tableRow)[0]);
    });
    tr.append(editLink);

    const removeLink = document.createElement("button");
    removeLink.setAttribute("data-id", Object.values(tableRow)[0]);
    removeLink.append("Delete");
    removeLink.addEventListener("click", e => {
        console.log('btn: delete clicked');
        e.preventDefault();
        deleteTableRow(Object.values(tableRow)[0]);
    });
    tr.append(removeLink);

    return tr;
}

function resetForm(){
    let form = document.getElementById('tableForm');
    const inputs = form.querySelectorAll("input");

    inputs.forEach(input => {
        input.value = "";
    });
}

document.getElementById('tableForm').addEventListener("submit", e => {
    e.preventDefault();
    const userInputElements = document.querySelectorAll('input[id="userInput"]');
    const userInputs = {};

    userInputElements.forEach((element) => {
        userInputs[element["name"]] = element.value
        //userInputValues.push(e);
    });

    console.log(userInputs);

    const id = document.getElementById('tableForm').elements["id-input"].value;;

    if (id == 0) createTableRow(userInputs);
    // else
        //editUser(id, name, age);  //TODO:
});
