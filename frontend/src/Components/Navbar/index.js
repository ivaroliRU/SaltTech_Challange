import React from 'react';
import './style.css';
import Cart from '../Cart';
import logo from '../../Assets/logo.png';

class Navbar extends React.Component {
    render() {
        return (
            <nav className="navbar fixed-top navbar-expand-lg navbar-light bg-light">
                <a className="navbar-brand" href="#">
                    <img src={logo} width="100" alt="" />
                </a>

                <ul className="navbar-nav ml-auto">
                    <Cart />
                </ul>
            </nav>
        );
    }
}

export default Navbar;