import React from 'react';
import './style.css';
import Cart from '../Cart';
import logo from '../../Assets/logo.png';
import {Wrapper, Brand, ItemList} from '../Shared/Navbar';

class Navbar extends React.Component {
    render() {
        return (
            <Wrapper>
                <Brand>
                    <img src={logo} width="100" alt="" />
                </Brand>

                <ItemList rightAlign>
                    <Cart />
                </ItemList>
            </Wrapper>
        );
    }
}

export default Navbar;