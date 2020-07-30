import { fetchProductsFromAPI } from '../../Services/productService';
import React from 'react';
import './style.css'
import ProductCard from '../ProductCard';
import { connect } from 'react-redux';
import {Row, Cell} from '../Shared';
import ProductContainerWrapper from './ProductContainerWrapper';

//a single row of 4 products
const ProductRow = ({ products }) => (
    <Row>
        {products.map(p => (
            <Cell key={"product-" + p.id}>
                <ProductCard product={p} />
            </Cell>
        ))}
    </Row>
);

//number of products on a page
const NUM_PRODUCTS_ON_PAGE = 12;

class ArtistModal extends React.Component {
    constructor(props) {
        super(props);

        this.handleChange = this.handleChange.bind(this);

        this.state = {
            data: [],
            prev_page: 0,
            prev_search: "",
            loading: false
        };
    }

    componentDidMount() {
        fetchProductsFromAPI("", this.props.page, NUM_PRODUCTS_ON_PAGE).then(res => { this.setState({ data: res }) });
    }

    //handle fetching new data from the api
    handleChange() {
        if (this.state.loading || (this.props.page === this.state.prev_page && this.props.search === this.state.prev_search)) {
            return;
        }

        //set a timeout for 100ms to make sure state transiton is done when the new data arrives...
        fetchProductsFromAPI(this.props.search, this.props.page, NUM_PRODUCTS_ON_PAGE)
            .then(res => {
                this.setState(
                    {
                        data: res, prev_page: this.props.page,
                        prev_search: this.props.search,
                        loading: false
                    })
            });
    }

    componentDidUpdate() {
        this.handleChange();
    }

    render() {
        return (
            <ProductContainerWrapper>
                {
                    this.state.data.chunk(4).map((l, i) => (
                        <ProductRow key={"product-row-" + i} products={l} />
                    ))
                }
            </ProductContainerWrapper>
        );
    }
}

function mapStateToProps(state) {
    return {
        page: state.page,
        search: state.search
    };
}

export default connect(mapStateToProps)(ArtistModal);