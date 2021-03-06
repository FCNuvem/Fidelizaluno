import React from 'react';
import ReactDOM from 'react-dom';
import * as serviceWorker from './serviceWorker';
import { BrowserRouter, Router } from 'react-router-dom';
import history from './history';
import { routes } from './routes';
import { Provider } from "react-redux";
import './index.scss';
import './app/config/ReactotronConfig'
import store from './store'

ReactDOM.render(
    <Provider store={store}>
        <BrowserRouter>
            <Router history={history}>
                {routes}
            </Router>
        </BrowserRouter>
    </Provider>
    , document.getElementById('root'));


// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: http://bit.ly/CRA-PWA
serviceWorker.unregister();
