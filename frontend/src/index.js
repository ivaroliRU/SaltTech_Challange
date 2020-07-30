import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';

//define a function for arrays that chunks them inti n sizes
/* eslint-disable no-extend-native */
Object.defineProperty(Array.prototype, 'chunk', {
    value: function (chunkSize) {
        var temporal = [];

        for (var i = 0; i < this.length; i += chunkSize) {
            temporal.push(this.slice(i, i + chunkSize));
        }

        return temporal;
    }
});
/* eslint-enable no-extend-native */

ReactDOM.render(
    <React.StrictMode>
        <App />
    </React.StrictMode>,
    document.getElementById('root')
);