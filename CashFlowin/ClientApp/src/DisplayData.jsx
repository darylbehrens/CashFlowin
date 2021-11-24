import * as React from 'react';
import { Component } from 'react';



let columns = [
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
        heading: 'Start Date',
        property: 'startDate'
    },
    {
        heading: 'End Date',
        property: 'endDate'
    },
    {
        heading: 'Skip',
        property: 'skip'
    }
]

//Data is the array of objects to be placed into the table
let data = [
    {
        id: '1',
        name: 'Food',
        value: 10,
        frequency: 'Daily',
        startDate: '7/1/1991',
        endDate: '7/1/2100',
        skip: 'No'
    },
    {
        id: '2',
        name: 'Gas',
        value: 50,
        frequency: 'Weekly',
        startDate: '7/1/1991',
        endDate: '7/1/2100',
        skip: 'Yes'
    },
    {
        id: '3',
        name: 'Pencil Lead',
        value: 5897,
        frequency: 'Monthly',
        startDate: '7/1/1991',
        endDate: '7/1/2100',
        skip: 'No'
    }
]

const ListData = ({ columns, data, propertyAsKey }) => //Deconstructs your props
    <table className='table'>
        <thead>
            <tr>
                <th>Save?</th>
                {columns.map(col => <th key={`header-${col.heading}`}>{col.heading}</th>)}
                <th>Delete?</th>
            </tr>
        </thead>
        <tbody>
            {data.map(item =>
                <tr key={`${item[propertyAsKey]}-row`}>
                    <td><button type="button">Save</button></td>
                    {columns.map(col => <td key={`${item[propertyAsKey]}-${col.property}`}>{item[col.property]}</td>)}
                    <td><input type="checkbox" id="DeleteData" /></td>
                </tr>
            )}
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