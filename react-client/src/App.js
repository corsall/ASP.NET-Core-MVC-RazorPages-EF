import { React, useState, useMemo, useEffect } from "react";
import RestaurantsTable from "./components/table/RestaurantsTable";
import "./styles/App.css";
import "./styles/tableStyles.css";
import "./styles/navBar.css";
import "./styles/sideBar.css";
import UsersInput from "./components/UsersInput";
import TableService from "./API/TableService";
import SearchSection from "./components/SearchSection";

function App() {
    const [tableData, setTableData] = useState([]);
    const [tableHeader, setTableHeader] = useState([]);
    const headerNumb = Object.keys(tableHeader).length;
    const [userInputs, setUserInputs] = useState(
        new Array(headerNumb).fill("")
    );
    const [searchQuery, setSearchQuery] = useState("");
    const [currentTable, setCurrentTable] = useState("");
    const [editMode, setEditMode] = useState(false);

    useEffect(() => {
        setCurrentTable("Clients");
        fetchTable("Clients");
    }, []);

    //TODO:
    async function createRow(newRow) {
        if (editMode) {
            await TableService.updateTableRow(currentTable, newRow);
            setTableData(
                [...tableData].map((element) =>
                    Object.values(element)[0] === Object.values(newRow)[0]
                        ? newRow
                        : element
                )
            );
            setEditMode(false);
            return;
        }
        for (let i = 0; i < Object.values(tableData).length; i++) {
            if (
                Object.values(Object.values(tableData)[i])[0] ===
                Object.values(newRow)[0]
            ) {
                window.alert("Cannot use the same ID");
                return;
            }
        }
        const request = await TableService.postTableRow(currentTable, newRow);
        if (request === undefined) {
            window.alert("Failed to add new row");
            return;
        }
        setTableData([...tableData, newRow]);
    }

    async function fetchTable(table) {
        let response = await TableService.getTable(table);
        setTableData(response);
        response = await TableService.getTableHeader(table);
        setTableHeader(response);
    }

    async function removeRow(row) {
        setTableData(
            tableData.filter(
                (r) => Object.values(r)[0] !== Object.values(row)[0]
            )
        );
        await TableService.deleteTableRow(currentTable, row);
    }

    //routing function
    function choseTable(table) {
        //clearing inputs
        setSearchQuery("");
        setUserInputs(new Array(headerNumb).fill(""));
        setEditMode(false);
        setCurrentTable(table);
        fetchTable(table);
    }

    function changeUserInput(row) {
        setUserInputs(row);
        setEditMode(true);
    }

    const tableSearch = useMemo(() => {
        const regex = RegExp(searchQuery);
        const filteredTableData = tableData.filter(
            (table) =>
                !Object.values(table)
                    .map((value) => (value === null ? "" : value.toString()))
                    .reduce((a, c) => a * !c.match(regex), true)
        );
        if (filteredTableData.length === 0) return tableData;
        return filteredTableData;
    }, [searchQuery, tableData]);

    return (
        <>
            <div className="sideBar">
                <SearchSection
                    choseTable={choseTable}
                    searchQuery={searchQuery}
                    setSearchQuery={setSearchQuery}
                />
                <hr style={{ margin: "15px 0" }} />
                <UsersInput
                    tableHeader={tableHeader}
                    userInputs={userInputs}
                    editMode={editMode}
                    create={createRow}
                />
            </div>
            <div className="main">
                <div className="navBar"></div>
                <RestaurantsTable
                    remove={removeRow}
                    tableContent={tableSearch}
                    tableHeader={Object.keys(tableHeader)}
                    setInitialUserVals={changeUserInput}
                />
            </div>
        </>
    );
}

export default App;
