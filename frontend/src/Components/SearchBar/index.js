import React from 'react';
import './style.css';
import { connect } from 'react-redux';
import { FaSearch } from 'react-icons/fa';
import { FetchProducts } from '../../Services/productService';

const SEARCH_SIZE = 4;

const SearchSuggestions = ({products, handleClick}) => (
    <ul className="search-suggestions">
        {products.map((p,i) => (
            <li key={"suggestion-"+i} className="product-suggestion" onClick={() => handleClick(p.name)}>
                {p.name}
            </li>
        ))}
    </ul>
);

class SearchBar extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            data: []
        }

        this.handleSearch = this.handleSearch.bind(this);
        this.handleCompleteSearch = this.handleCompleteSearch.bind(this);
    }

    componentDidMount(){
        document.getElementById("searchbar-input").addEventListener("keydown", e => {
            if (e.keyCode === 13) {
                this.handleCompleteSearch(e.target.value)
            }
        });
    }

    //handle search bar function
    handleSearch(e){
        let value = e.target.value;

        if(value == ""){
            this.setState({data: []});
            return;
        }

        FetchProducts(value, 0, SEARCH_SIZE).then(res => {
            this.setState({data: res});
        });
    }

    handleCompleteSearch(name){
        this.props.changeSearch(name);
        this.setState({data: []});
        document.getElementById('searchbar-input').value = '';
    }

    render() {
        return (
            <div className="search-bar input-group">
                <input onChange={this.handleSearch} autoComplete="off" type="text" id="searchbar-input" className="form-control" aria-label="Search for products" placeholder={(this.props.search == "")?"Search for products":this.props.search} />
                <div className="input-group-append">
                    <span className="input-group-text"><FaSearch /></span>
                </div>
                <SearchSuggestions products={this.state.data} handleClick={(name) => this.handleCompleteSearch(name)} />
            </div>
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
        changeSearch: (search) => dispatch({type: 'CHANGE_SEARCH', payload:search})
    };
};

export default connect(mapStateToProps,mapDispatchToProps)(SearchBar);