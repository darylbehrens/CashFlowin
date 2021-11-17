import React, { Component } from 'react';

const Output = () => {
    return (
        <form id="InsertItem" className="DesignBorder">
            <h2>Insert Item</h2>
            <div>
                <input type="text" id="Name" defaultValue="Item Name" /><br/>
                <input type="text" id="Value" defaultValue="Item Value" /><br/>
                <select name="Frequency" id="Frequency">
                    <option value="weekly">Weekly</option>
                    <option value="monthly">Monthly</option>
                    <option value="yearly">Yearly</option>
                </select><br />
                <input type="submit" value="Insert" />
            </div>
        </form>
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