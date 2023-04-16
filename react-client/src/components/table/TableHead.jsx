import React from "react";

function TableHead({tableHeader}) {
    return (
        <thead>
            <tr>
                {tableHeader.map((head, index) => (
                    <th key={index}>{head}</th>
                ))}
            </tr>
        </thead>
    );
}

export default TableHead;
