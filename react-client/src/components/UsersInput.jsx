import { React, useMemo, useState } from "react";
import MyButton from "./UI/button/MyButton";
import MyInput from "./UI/input/MyInput";

//TODO:
function UsersInput({ userInputs, create, tableHeader, editMode }) {
    const [rowsInput, setRowsInput] = useState(userInputs);
    useMemo(() => {
        setRowsInput(userInputs);
    }, [userInputs]);

    function addNewRow(e) {
        e.preventDefault();
        const newRow = {};
        for (let i = 0; i < rowsInput.length; i++) {
            newRow[Object.values(tableHeader)[i]] = rowsInput[i]; 
        }
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
                let isDisabled = false;
                if(index === 0 && editMode) {
                    isDisabled = true;
                }
                return (
                    <MyInput
                        key={key}
                        value={Object.values(rowsInput)[index] || ""}
                        onChange={(e) => {
                            setRowsInput((row) => {
                                let copy = [...rowsInput];
                                copy[index] = e.target.value;
                                return copy;
                            });
                        }}
                        type="text"
                        placeholder={key}
                        disabled={isDisabled}
                    />
                );
            })}
            <MyButton onClick={addNewRow}>Save</MyButton>
            <MyButton onClick={clearForm}>Clear</MyButton>
        </form>
    );
}

export default UsersInput;
