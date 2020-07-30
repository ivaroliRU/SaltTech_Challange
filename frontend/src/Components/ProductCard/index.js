import React from 'react';
import { connect } from 'react-redux';
import {Wrapper, Body, Title, Text, Image} from '../Shared/Card';
import {Button} from '../Shared';

class ProductCard extends React.Component {
    render() {
        return (
            <Wrapper>
                <Image src={"https://dummyimage.com/250/ffffff/000000"} alt="Card image cap" />
                <Body>
                    <Title>{this.props.product.name}</Title>
                    <Text>{this.props.product.price} $</Text>
                    <Button primary onClick={() => this.props.addToCart(this.props.product)}>Add to cart</Button>
                </Body>
            </Wrapper>
        );
    }
}

function mapStateToProps(state) {
    return {
        cart: state.cart
    };
}

const mapDispatchToProps = dispatch => {
    return {
        addToCart: (item) => dispatch({ type: 'ADD_TO_CART', payload: item })
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(ProductCard);