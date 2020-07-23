import React from 'react';
import Navbar from './Components/Navbar';
import Header from './Components/Header';
import Pagination from './Components/Pagination';
import ProductsContainer from './Components/ProductsContainer';

function AppContainer() {
  return (
    <div className="App">
        <Navbar />
        <Header />
        <ProductsContainer />
        <Pagination />
      </div>
  );
}

export default AppContainer;