import React from 'react';
import SearchbarWrapper from './SearchbarWrapper';
import SearchbarAddon from './SearchbarAddon';
import SearchbarInput from './SearchbarInput';
import SearchSuggestions from './SearchSuggestions';
import { connect } from 'react-redux';
import { FaSearch } from 'react-icons/fa';
import { fetchProductsFromAPI } from '../../Services/productService';

const SEARCH_SIZE = 4;

class SearchBar extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            data: []
        }

        this.handleSearch = this.handleSearch.bind(this);
        this.handleCompleteSearch = this.handleCompleteSearch.bind(this);
    }

    componentDidMount() {
        document.getElementById("searchbar-input").addEventListener("keydown", e => {
            if (e.keyCode === 13) {
                this.handleCompleteSearch(e.target.value)
            }
        });
    }

    //handle fetching products for suggestions
    handleSearch(e) {
        let value = e.target.value;

        if (value === "") {
            this.setState({ data: [] });
            return;
        }

        fetchProductsFromAPI(value, 0, SEARCH_SIZE).then(res => {
            this.setState({ data: res });
        });
    }

    //reset the search bar and suggestion box
    handleCompleteSearch(name) {
        this.props.changeSearch(name);
        this.setState({ data: [] });
        document.getElementById('searchbar-input').value = '';
    }

    render() {
        return (
            <SearchbarWrapper>
                <SearchbarInput onChange={this.handleSearch} autoComplete="off" type="text" id="searchbar-input" aria-label="Search for products" placeholder={(this.props.search === "") ? "Search for products" : this.props.search} />
                <SearchbarAddon><FaSearch /></SearchbarAddon>
                <SearchSuggestions products={this.state.data} handleClick={(name) => this.handleCompleteSearch(name)} />
            </SearchbarWrapper>
        );
    }
}

function mapStateToProps(state) {
    return {
        search: state.search
    };
}

const mapDispatchToProps = dispatch => {
    return {
        changeSearch: (search) => dispatch({ type: 'CHANGE_SEARCH', payload: search })
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(SearchBar);