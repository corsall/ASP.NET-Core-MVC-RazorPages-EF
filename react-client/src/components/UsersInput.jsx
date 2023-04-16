import { React, useState, useEffect } from "react";
import MyButton from "./UI/button/MyButton";
import MyInput from "./UI/input/MyInput";

function UsersInput({ tableHeader, create, initialValues }) {
    //tableHeaderArr ['kodkl', 'namekl'] => {kodkl: '', namekl: ''}
    const tableHeaderArr = Object.values(tableHeader);
    const tableHeaderObj = {};

    for (let i = 0; i < tableHeaderArr.length; i++) {
        tableHeaderObj[tableHeaderArr[i]] = initialValues[i];
    }

    const [rowData, setRowData] = useState(tableHeaderObj);

    useEffect(() => {
        setRowData(tableHeaderObj);
    }, [initialValues]);

    function clear(){
        const cleanHeaderObj ={};
        for (let i = 0; i < tableHeaderArr.length; i++) {
            cleanHeaderObj[tableHeaderArr[i]] = '';
        }
        return cleanHeaderObj;
    }

    function addNewRow(e) {
        e.preventDefault();
        const newRow = {
            ...rowData,
        };
        create(newRow);
        
        setRowData(clear()); //clear inputs
    }

    function clearForm(e) {
        e.preventDefault();
        setRowData(clear());
    }

    return (
        <form>
            {Object.keys(tableHeader).map((key, index) => {
                return (
                    <MyInput
                        key={key}
                        value={Object.values(rowData)[index]}
                        onChange={(e) =>
                            setRowData({
                                ...rowData,
                                [tableHeader[key]]: e.target.value,
                            })
                        }
                        type="text"
                        placeholder={key}
                    />
                );
            })}
            <MyButton onClick={addNewRow}>Save</MyButton>
            <MyButton onClick={clearForm}>Clear</MyButton>
        </form>
    );
}

export default UsersInput;
