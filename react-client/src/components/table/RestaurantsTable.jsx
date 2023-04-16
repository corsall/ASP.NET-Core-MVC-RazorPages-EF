import React from "react";
import TableBody from "./TableBody";
import TableHead from "./TableHead";

function RestaurantsTable({
    remove,
    tableContent,
    tableHeader,
    setInitialUserVals,
}) {
    return (
        <table>
            <TableHead tableHeader={tableHeader} />
            <TableBody
                remove={remove}
                tableContent={tableContent}
                setInitialUserVals={setInitialUserVals}
            />
        </table>
    );
}

export default RestaurantsTable;
