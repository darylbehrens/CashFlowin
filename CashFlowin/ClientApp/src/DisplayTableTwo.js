"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.GenericTable = void 0;
var React = require("react");
var GenericTable_module_css_1 = require("./GenericTable.module.css");
var GenericTable = function (_a) {
    var model = _a.model, elements = _a.elements;
    var sumWidth = model.columns.reduce(function (sum, column) { return sum + (column.width || 1); }, 0);
    var widthOf = function (c) { return ((c.width || 1) / sumWidth) * 100; };
    return (React.createElement("div", { className: GenericTable_module_css_1.default.genericTableContainer },
        React.createElement("div", { className: GenericTable_module_css_1.default.genericTableHeader },
            React.createElement("div", { className: GenericTable_module_css_1.default.genericTableRow }, model.columns.map(function (c) {
                return React.createElement("div", { className: GenericTable_module_css_1.default.genericTableCell, style: { width: widthOf(c) + "%" } },
                    React.createElement("span", { className: GenericTable_module_css_1.default.genericTableCellText }, c.title));
            }))),
        React.createElement("div", { className: GenericTable_module_css_1.default.genericTableBody }, elements.map(function (e) {
            return React.createElement("div", { className: GenericTable_module_css_1.default.genericTableRow }, model.columns.map(function (c) {
                return React.createElement("div", { className: GenericTable_module_css_1.default.genericTableCell, style: { width: widthOf(c) + "%" } }, c.html(e));
            }));
        }))));
};
exports.GenericTable = GenericTable;
//# sourceMappingURL=DisplayTableTwo.js.map