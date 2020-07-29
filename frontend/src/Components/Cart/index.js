import React from 'react';
import './style.css';
import { FaShoppingCart, FaTimes } from 'react-icons/fa';
import logo from '../../Assets/logo.png';
import { connect } from 'react-redux';

//container that holds the list of items in the cart
const CartContainer = ({ items, remove, clear }) => (
    <ul className="cart-container">
        {items.map((i, index) => (
            <li className="cart-item"><FaTimes color="red" onClick={() => remove(index)} />{i.name}</li>
        ))}
        <li className="divider"></li>
        <div className="row cart-options">
            <div className="col-6" id="clear-cart" onClick={() => clear()}>
                Clear Cart
            </div>
            <div className="col-6">
                Checkout
            </div>
        </div>
    </ul>
);

class Cart extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            show_cart: false
        };
    }

    render() {
        return (
            <React.Fragment>
                <div className="nav-item cart">
                    <a onClick={() => this.setState({ show_cart: !this.state.show_cart })} className="nav-link"><FaShoppingCart size={25} color="#FFF" />{(this.props.cart.length > 0) ? <span className="badge badge-primary">{this.props.cart.length}</span> : null}</a>
                </div>
                {this.state.show_cart && this.props.cart.length > 0 && <CartContainer items={this.props.cart} remove={(i) => this.props.removeFromCart(i)} clear={() => this.props.clearCart()} />}
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