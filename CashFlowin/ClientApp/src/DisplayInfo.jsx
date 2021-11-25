import React, { Component } from 'react';

const Output = () => {
    return (
        <div id="DisplayInfo" className="DesignBorder">
            <h2>Item Info</h2>
            <p>Name of bill. i.e. Gas, Rent, Electric</p>
            <p>How much the bill is. i.e. $40, $400, $4000</p>
            <p>How frequently this bill must be paid. i.e. Weekly, Monthly, Yearly</p>
        </div>
    );
}

class AddItem extends Component {
    render() {
        return (
            <Output />
        )
    }
}

export default AddItem;