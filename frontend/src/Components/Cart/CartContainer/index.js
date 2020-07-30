import React from 'react';
import { FaTimes } from 'react-icons/fa';
import Wrapper from './Wrapper';
import CartButton from './CartButton';
import CartItem from './CartItem';
import {Row, Cell, Divider} from '../../Shared';

//container that holds the list of items in the cart
export default ({ show, items, remove, clear }) => (
    <Wrapper show={items.length > 0 && show}>
        {items.map((i, index) => (
            <CartItem key={"cart-item-"+index}><FaTimes color="red" onClick={() => remove(index)} />{i.name}</CartItem>
        ))}
        <Divider />
        <Row>
            <Cell size={6} onClick={() => clear()}>
                <CartButton>Clear Cart</CartButton>
            </Cell>
            <Cell size={6}>
                <CartButton>Checkout</CartButton>
            </Cell>
        </Row>
    </Wrapper>
);