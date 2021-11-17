import * as React from 'react';
import { Component } from 'react';



let columns = [
    {
        heading: 'Save',
        property: 'save'
    },
    {
        heading: 'Id',
        property: 'id'
    },
    {
        heading: 'Name',
        property: 'name'
    },
    {
        heading: 'Value',
        property: 'value'
    },
    {
        heading: 'Frequency',
        property: 'frequency'
    },
    {
        heading: 'Delete',
        property: 'delete'
    }
]

//Data is the array of objects to be placed into the table
let data = [
    {
        id: '1',
        name: 'Food',
        value: 10,
        frequency: 'Daily'
    },
    {
        id: '2',
        name: 'Gas',
        value: 50,
        frequency: 'Weekly'
    },
    {
        id: '3',
        name: 'Pencil Lead',
        value: 5897,
        frequency: 'Monthly'
    }
]

const ListData = ({ columns, data, propertyAsKey }) => //Deconstructs your props
    <table className='table'>
        <thead>
            {/*<tr>{columns.map(col => <th key={`header-${col.heading}`}>{col.heading}</th>)}</tr>*/}
            <tr>
                <th>Save?</th>
                <th>Name</th>
                <th>Value</th>
                <th>Frequency</th>
                <th>Delete?</th>
            </tr>
        </thead>
        <tbody>
            {/*{data.map(item =>*/}
            {/*    <tr key={`${item[propertyAsKey]}-row`}>*/}
            {/*        <td><button type="button">Save</button></td>*/}
            {/*        {columns.map(col => <td key={`${item[propertyAsKey]}-${col.property}`}>{item[col.property]}</td>)}*/}
            {/*        <td><input type="checkbox" id="DeleteData" /></td>*/}
            {/*    </tr>*/}
            {/*)}*/}
            <tr>
                <td><button type="button">Save</button></td>
                <td>Gas</td>
                <td>40</td>
                <td>Weekly</td>
                <td><input type="checkbox" id="DeleteData" /></td>
            </tr>
            <tr>
                <td><button type="button">Save</button></td>
                <td>Food</td>
                <td>400</td>
                <td>Monthly</td>
                <td><input type="checkbox" id="DeleteData" /></td>
            </tr>
            <tr>
                <td><button type="button">Save</button></td>
                <td>Rent</td>
                <td>4000</td>
                <td>Yearly</td>
                <td><input type="checkbox" id="DeleteData" /></td>
            </tr>
        </tbody>
    </table>

const Output = () => {
    return (
        <div id="DisplayData" className="DesignBorder">
            <h2>Display Table Data</h2>
            <ListData
                columns={columns}
                data={data}
                propertyAsKey='Id'
            />
        </div>
    );
}

class DisplayData extends Component {
    render() {
        return (
            <Output />
        )
    }
}

export default DisplayData;