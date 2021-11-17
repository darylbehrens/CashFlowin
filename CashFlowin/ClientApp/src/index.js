"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
require("bootstrap/dist/css/bootstrap.css");
var React = require("react");
var ReactDOM = require("react-dom");
var react_redux_1 = require("react-redux");
var connected_react_router_1 = require("connected-react-router");
var history_1 = require("history");
var configureStore_1 = require("./store/configureStore");
var registerServiceWorker_1 = require("./registerServiceWorker");
var DisplayData_1 = require("./DisplayData");
var AddItem_1 = require("./AddItem");
var DisplayInfo_1 = require("./DisplayInfo");
require("./BasicStyle.css");
// Create browser history to use in the Redux store
var baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
var history = (0, history_1.createBrowserHistory)({ basename: baseUrl });
// Get the application-wide store instance, prepopulating with state from the server where available.
var store = (0, configureStore_1.default)(history);
var Output = function () {
    return (React.createElement("div", { className: "GridContainer" },
        React.createElement(AddItem_1.default, null),
        React.createElement(DisplayInfo_1.default, null)));
};
ReactDOM.render(React.createElement(react_redux_1.Provider, { store: store },
    React.createElement(connected_react_router_1.ConnectedRouter, { history: history },
        React.createElement(DisplayData_1.default, null),
        React.createElement(Output, null))), document.getElementById('root'));
(0, registerServiceWorker_1.default)();
//# sourceMappingURL=index.js.map