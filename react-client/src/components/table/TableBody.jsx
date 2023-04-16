import React from "react";
import TableRow from "./TableRow";

function TableBody({tableContent}) {
    return (
        <tbody>
            {tableContent.map((row) => (
                <TableRow key={Object.values(row)[0] + Date.now()} row={row}/>
            ))}
        </tbody>
    );
}

export default TableBody;
