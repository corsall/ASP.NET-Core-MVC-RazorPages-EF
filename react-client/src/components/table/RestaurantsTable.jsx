import React from "react";
import TableBody from "./TableBody";
import TableHead from "./TableHead";

function RestaurantsTable({ tableContent, tableHeader }) {
    return (
        <table>
            <TableHead tableHeader={tableHeader}/>
            <TableBody tableContent={tableContent} />
        </table>
    );
}

export default RestaurantsTable;
