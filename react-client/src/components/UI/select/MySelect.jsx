import React from "react";

function MySelect({ options, defaultValue, onChange }) {
    return (
        <select
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
