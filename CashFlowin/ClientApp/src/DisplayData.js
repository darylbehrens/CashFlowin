"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_1 = require("react");
var columns = [
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
];
//Data is the array of objects to be placed into the table
var data = [
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
];
var ListData = function (_a) {
    var columns = _a.columns, data = _a.data, propertyAsKey = _a.propertyAsKey;
    return React.createElement("table", { className: 'table' },
        React.createElement("thead", null,
            React.createElement("tr", null,
                React.createElement("th", null, "Save?"),
                React.createElement("th", null, "Name"),
                React.createElement("th", null, "Value"),
                React.createElement("th", null, "Frequency"),
                React.createElement("th", null, "Delete?"))),
        React.createElement("tbody", null,
            React.createElement("tr", null,
                React.createElement("td", null,
                    React.createElement("button", { type: "button" }, "Save")),
                React.createElement("td", null, "Gas"),
                React.createElement("td", null, "40"),
                React.createElement("td", null, "Weekly"),
                React.createElement("td", null,
                    React.createElement("input", { type: "checkbox", id: "DeleteData" }))),
            React.createElement("tr", null,
                React.createElement("td", null,
                    React.createElement("button", { type: "button" }, "Save")),
                React.createElement("td", null, "Food"),
                React.createElement("td", null, "400"),
                React.createElement("td", null, "Monthly"),
                React.createElement("td", null,
                    React.createElement("input", { type: "checkbox", id: "DeleteData" }))),
            React.createElement("tr", null,
                React.createElement("td", null,
                    React.createElement("button", { type: "button" }, "Save")),
                React.createElement("td", null, "Rent"),
                React.createElement("td", null, "4000"),
                React.createElement("td", null, "Yearly"),
                React.createElement("td", null,
                    React.createElement("input", { type: "checkbox", id: "DeleteData" })))));
};
var Output = function () {
    return (React.createElement("div", { id: "DisplayData", className: "DesignBorder" },
        React.createElement("h2", null, "Display Table Data"),
        React.createElement(ListData, { columns: columns, data: data, propertyAsKey: 'Id' })));
};
var DisplayData = /** @class */ (function (_super) {
    __extends(DisplayData, _super);
    function DisplayData() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    DisplayData.prototype.render = function () {
        return (React.createElement(Output, null));
    };
    return DisplayData;
}(react_1.Component));
exports.default = DisplayData;
//# sourceMappingURL=DisplayData.js.map