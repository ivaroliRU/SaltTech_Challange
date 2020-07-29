const BASE_URL = "http://localhost:5000"

//fetch products from our API with a search string
export function fetchProducts(searchString, page, page_size) {
    return new Promise(resolve => {

        let url = `${BASE_URL}/api/products?page=${page}&page_size=${page_size}`;

        if (searchString !== "") {
            url = `${url}&name=${searchString}`;
        }

        fetch(url)
            .then(function (res) {
                if (res.status === 200) {
                    return res.json();
                }
                else {
                    alert("An error occourd fetching the products");
                    resolve([]);
                }
            })
            .then(json => {
                resolve(json)
            });
    });
}