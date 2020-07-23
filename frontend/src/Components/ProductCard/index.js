import React from 'react';
import './style.css';
import { connect } from 'react-redux';

class ProductCard extends React.Component {
    constructor(props) {
        super(props);
    }
    
    render() {
        //let image = this.props.product.image.replace("[","").replace("]","").replace("\"","").replace(" ","").split(",")[0];

        return (
            <div className="card product-card">
                <img className="card-img-top" src={"https://dummyimage.com/250/ffffff/000000"} alt="Card image cap" />
                <div className="card-body">
                    <h6 className="card-title">{this.props.product.name}</h6>
                    <p className="card-text">{this.props.product.price} $</p>
                    <a className="btn btn-primary" onClick={() => this.props.addToCart(this.props.product)}>Add to cart</a>
                </div>
            </div>
        );
    }
}

function mapStateToProps(state){
    return{
        cart: state.cart
    };
}

const mapDispatchToProps = dispatch => {
    return {
        addToCart: (item) => dispatch({type: 'ADD_TO_CART', payload:item})
    };
};

export default connect(mapStateToProps,mapDispatchToProps)(ProductCard);