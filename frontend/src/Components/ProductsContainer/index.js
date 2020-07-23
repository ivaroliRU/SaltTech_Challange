import { FetchProducts } from '../../Services/productService';
import React from 'react';
import './style.css'

class ArtistModal extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            data: []
        };
    }

    componentDidMount(){
        FetchProducts("").then(res => {this.setState({data: res})});
    }

    render() {
        console.log(this.state.data);

        return (
            <div className="products-container">
            </div>
        );
    }
}

export default ArtistModal;