import React, { Component } from 'react';

const Output = () => {
    return (
        <div id="DisplayInfo" className="DesignBorder">
            <h2>Item Info</h2>
            <p>Name of bill. i.e. Gas, Rent, Electric</p>
            <p>How much the bill is. i.e. $40, $400, $4000</p>
            <p>How frequently this bill must be paid. i.e. Weekly, Monthly, Yearly</p>
            <p>The start date of this bill</p>
            <p>The end date of this bill (when it's done). i.e. debts, CC payments, savings plans, etc.</p>
            <p>Does this skipp every 2 weeks? Every 4 weeks? Leave blank for bill occurs weekly</p>
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