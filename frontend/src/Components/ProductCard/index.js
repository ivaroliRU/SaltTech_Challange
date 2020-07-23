import React from 'react';
import './style.css'

function ProductCard({name, image, price}) {
    image = image.replace("[","").replace("]","").replace("\"","").replace(" ","").split(",")[0];

    return (
        <div className="card product-card">
            <img className="card-img-top" src={"https://dummyimage.com/250/ffffff/000000"} alt="Card image cap" />
            <div className="card-body">
                <h6 className="card-title">{name}</h6>
                <p className="card-text">{price} $</p>
                <a href="#" className="btn btn-primary">Add to cart</a>
            </div>
        </div>
    );
}

export default ProductCard;