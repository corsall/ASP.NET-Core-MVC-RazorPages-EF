import { React, useState } from "react";
import RestaurantsTable from "./components/table/RestaurantsTable";
import "./styles/App.css";
import UsersInput from "./components/UsersInput";


function App() {
    const [tableData, setTableData] = useState(ORDERS);
    const [tableHeader, setTableHeader] = useState(ORDERSHEADER);

    function createRow(newRow) {
        setTableData([...tableData, newRow]);
    }

    return (
        <>
            <UsersInput create={createRow} tableHeader={tableHeader}/>
            <RestaurantsTable
                tableContent={tableData}
                tableHeader={Object.keys(tableHeader)}
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
