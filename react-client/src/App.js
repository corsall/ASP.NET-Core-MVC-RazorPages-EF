import { React, useState } from "react";
import RestaurantsTable from "./components/table/RestaurantsTable";
import "./styles/App.css";
import UsersInput from "./components/UsersInput";
import MySelect from "./components/UI/select/MySelect";

function App() {
    const [tableData, setTableData] = useState(CLIENTS);
    const [tableHeader, setTableHeader] = useState(CLIENTSHEADER);
    const headerNumb = Object.keys(tableHeader).length;
    const [userInputs, setUserInputs] = useState(
        new Array(headerNumb).fill("")
    );

    function createRow(newRow) {
        setTableData([...tableData, newRow]);
    }

    function removeRow(row) {
        setTableData(
            tableData.filter(
                (r) => Object.values(r)[0] !== Object.values(row)[0]
            )
        );
    }

    function choseTable(table) {
        //clearing inputs
        setUserInputs(new Array(headerNumb).fill(""));
        if (table === "CLIENTS") {
            setTableData(CLIENTS);
            setTableHeader(CLIENTSHEADER);
        } else if (table === "ORDERS") {
            setTableData(ORDERS);
            setTableHeader(ORDERSHEADER);
        }
    }

    function changeUserInput(row){
        setUserInputs(row);
    }

    return (
        <>
            <MySelect
                onChange={choseTable}
                defaultValue="Обрати таблицю"
                options={[
                    { value: "CLIENTS", name: "Клієнти" },
                    { value: "ORDERS", name: "Замовлення" },
                ]}
            />
            <hr style={{ margin: "15px 0" }} />
            <UsersInput
                tableHeader={tableHeader}
                userInputs={userInputs}
                create={createRow}
            />
            <RestaurantsTable
                remove={removeRow}
                tableContent={tableData} //tableData
                tableHeader={Object.keys(tableHeader)}
                setInitialUserVals={changeUserInput}
            />
        </>
    );
}

// tableContent={ORDERS}
// tableHeader={Object.keys(ORDERSHEADER)}

export default App;

const CLIENTS = [
    {
        kodkl: 11,
        namekl: 'Ресторан "Дубки"',
    },
    {
        kodkl: 22,
        namekl: "Їдальня №2",
    },
    {
        kodkl: 33,
        namekl: 'Кафе "Світлана"',
    },
    {
        kodkl: 44,
        namekl: 'Кафе "Вікторія"',
    },
    {
        kodkl: 55,
        namekl: 'Ресторан "Сатурн"',
    },
];

const CLIENTSHEADER = {
    "Код Клієнта": "kodkl",
    "Назва Клієнта": "namekl",
};

const ORDERS = [
    {
        nz: 10101,
        kodkl: 11,
        datez: "2019-01-01",
        datesp: "2019-01-01",
        koddos: 1,
    },
    {
        nz: 20202,
        kodkl: 22,
        datez: "2019-01-02",
        datesp: "2019-10-02",
        koddos: 2,
    },
    {
        nz: 30303,
        kodkl: 33,
        datez: "2019-01-03",
        datesp: null,
        koddos: 1,
    },
    {
        nz: 40404,
        kodkl: 44,
        datez: "2019-09-05",
        datesp: "2019-01-05",
        koddos: 2,
    },
    {
        nz: 50505,
        kodkl: 55,
        datez: "2019-01-05",
        datesp: "2019-01-05",
        koddos: 1,
    },
    {
        nz: 60606,
        kodkl: 11,
        datez: "2019-01-06",
        datesp: "2019-01-06",
        koddos: 2,
    },
    {
        nz: 70707,
        kodkl: 22,
        datez: "2019-07-07",
        datesp: "2019-11-07",
        koddos: 1,
    },
    {
        nz: 80808,
        kodkl: 33,
        datez: "2019-08-08",
        datesp: "2019-01-08",
        koddos: 1,
    },
    {
        nz: 90909,
        kodkl: 44,
        datez: "2019-09-09",
        datesp: "2019-09-19",
        koddos: 1,
    },
    {
        nz: 101010,
        kodkl: 55,
        datez: "2019-01-10",
        datesp: "2019-01-10",
        koddos: 2,
    },
];

const ORDERSHEADER = {
    "Номер Замовлення": "nz",
    "Код Клієнта": "kodkl",
    "Дата Замовлення": "datez",
    "Дата Сплати": "datesp",
    "Код Доставки": "koddos",
};
