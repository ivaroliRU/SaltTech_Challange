import React from 'react';
import './style.css';
import { FaShoppingCart, FaTimes } from 'react-icons/fa';
import { connect } from 'react-redux';
import {Item, Link} from '../Shared/Navbar';
import {Badge} from '../Shared';
import CartContainer from './CartContainer/index';

class Cart extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            show_cart: false
        };
    }

    render() {
        console.log(this.state.show_cart);
        
        return (
            <React.Fragment>
                <Item>
                    <Link onClick={() => this.setState({ show_cart: !this.state.show_cart })}>
                        <FaShoppingCart size={25} color="#FFF" />
                        <Badge show={this.props.cart.length !== 0} primary>{this.props.cart.length}</Badge>
                    </Link>
                </Item>
                <CartContainer show={this.state.show_cart} items={this.props.cart} remove={(i) => this.props.removeFromCart(i)} clear={() => this.props.clearCart()} />
            </React.Fragment>
        );
    }
}

const mapDispatchToProps = dispatch => {
    return {
        removeFromCart: (i) => dispatch({ type: 'REMOVE_FROM_CART', payload: i }),
        clearCart: () => dispatch({ type: 'CLEAR_CART' })
    };
};

function mapStateToProps(state) {
    return {
        cart: state.cart
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(Cart);