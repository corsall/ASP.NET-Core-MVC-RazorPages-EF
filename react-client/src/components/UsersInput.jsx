import { React, useMemo, useState } from "react";
import MyButton from "./UI/button/MyButton";
import MyInput from "./UI/input/MyInput";

function UsersInput({ userInputs, create, tableHeader }) {
    const [rowsInput, setRowsInput] = useState(userInputs);
    useMemo(() => {
        setRowsInput(userInputs);
    }, [userInputs]);

    function addNewRow(e) {
        e.preventDefault();
        const newRow = [...rowsInput];
        create(newRow);
        //clear inputs
        setRowsInput(Array(rowsInput.length).fill(''));
    }

    function clearForm(e) {
        e.preventDefault();
        //clear inputs
        setRowsInput(Array(rowsInput.length).fill(''));
        console.log(rowsInput);
    }

    return (
        <form>
            {Object.keys(tableHeader).map((key, index) => {
                return (
                    <MyInput
                        key={key}
                        value={Object.values(rowsInput)[index] || ""}
                        onChange={(e) => {
                            console.log([...rowsInput]);
                            setRowsInput((row) => {
                                let copy = [...rowsInput];
                                copy[index] = e.target.value;
                                return copy;
                            });
                        }}
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
