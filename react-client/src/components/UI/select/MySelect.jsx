import React from "react";
import classes from "./MySelect.module.css";

function MySelect({ options, defaultValue, onChange }) {
    return (
        <select
            className={classes.mySlct}
            onChange={event => onChange(event.target.value)}
        >
            <option disabled value="">{defaultValue}</option>
            {options.map(option =>
                <option key={option.value} value={option.value}>{option.name}</option>
            )}

        </select>
    );
}

export default MySelect;
