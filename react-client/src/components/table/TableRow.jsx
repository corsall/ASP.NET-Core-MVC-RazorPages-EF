import React from "react";
import MyButton from "../UI/button/MyButton";

function TableRow({ row, remove, setInitialUserVals }) {
    return (
        //key={Object.values(row)[0]}> always get the value of the first item of an object
        <tr>
            {Object.entries(row).map(([k, value], index) => {
                return (
                    <td
                        key={Number.parseInt(Object.values(row)[0]) + index}
                        id={k}
                    >
                        {value}
                    </td>
                );
            })}

            <td className="buttons">
                <MyButton onClick={() => remove(row)}>Delete</MyButton>
            </td>
            <td className="buttons">
                <MyButton onClick={() => setInitialUserVals(Object.values(row))}>Edit</MyButton>
            </td>
        </tr>
    );
}

export default TableRow;
