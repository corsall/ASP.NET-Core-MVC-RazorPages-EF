import { React, useState } from "react";
import MyButton from "./UI/button/MyButton";
import MyInput from "./UI/input/MyInput";

function UsersInput({ tableHeader, create }) {
    //tableHeaderArr ['kodkl', 'namekl'] => {kodkl: '', namekl: ''}
    const tableHeaderArr = Object.values(tableHeader);
    const tableHeaderObj = {};

    for (let i = 0; i < tableHeaderArr.length; i++) {
        tableHeaderObj[tableHeaderArr[i]] = "";
    }

    const [rowData, setRowData] = useState(tableHeaderObj);

    function addNewRow(e) {
        e.preventDefault();
        const newRow = {
            ...rowData,
        };
        create(newRow);

        setRowData(tableHeaderObj); //clear inputs
    }

    return (
        <form>
            {Object.keys(tableHeader).map((key,index) => {
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
        </form>
    );
}

export default UsersInput;
