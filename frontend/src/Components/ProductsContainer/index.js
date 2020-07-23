import { FetchProducts } from '../../Services/productService';
import React from 'react';
import './style.css'
import ProductCard from '../ProductCard';
import { connect } from 'react-redux';

//a single row of 4 products
const ProductRow = ({products}) => (
    <div className="row product-row">
        {products.map(p => (
            <div className="col-3" key={"product-"+p.id}>
                <ProductCard name={p.name} image={p.imageSource} price={p.price} />
            </div>
        ))}
    </div>
);

//number of products on a page
const NUM_PRODUCTS_ON_PAGE = 12;

class ArtistModal extends React.Component {
    constructor(props) {
        super(props);

        this.handleChange = this.handleChange.bind(this);

        this.state = {
            data: [],
            prev_page: 0
        };
    }

    componentDidMount(){
        FetchProducts("", this.props.page, NUM_PRODUCTS_ON_PAGE).then(res => {this.setState({data: res})});
    }

    handleChange(){
        if(this.props.page === this.state.prev_page){
            return;
        }

        FetchProducts("", this.props.page, NUM_PRODUCTS_ON_PAGE).then(res => {this.setState({data: res, prev_page: this.props.page})});
    }

    render() {
        this.handleChange();
        
        return (
            <div className="products-container">
                {
                    this.state.data.chunk(4).map((l, i) => (
                        <ProductRow key={"product-row-"+i} products={l} />
                    ))
                }
            </div>
        );
    }
}

function mapStateToProps(state){
    return{
        page: state.page,
    };
}

export default connect(mapStateToProps)(ArtistModal);