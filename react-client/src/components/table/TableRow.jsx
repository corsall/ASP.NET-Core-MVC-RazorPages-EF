import React from "react";

function TableRow({row}) {
    return (
        //key={Object.values(row)[0]}> always get the value of the first item of an object
        <tr>
            {Object.entries(row).map(([k, value], index) => {
                return (
                    <td key={Number.parseInt(Object.values(row)[0]) + index} id={k}>
                        {value}
                    </td>
                );
            })}
        </tr>
    );
}

export default TableRow;
