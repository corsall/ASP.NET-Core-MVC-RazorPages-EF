import React from "react";
import TableRow from "./TableRow";

function TableBody({ remove, tableContent, setInitialUserVals }) {
    return (
        <tbody>
            {tableContent.map((row) => (
                <TableRow
                    remove={remove}
                    key={Object.values(row)[0]}
                    row={row}
                    setInitialUserVals={setInitialUserVals}
                />
            ))}
        </tbody>
    );
}

export default TableBody;
