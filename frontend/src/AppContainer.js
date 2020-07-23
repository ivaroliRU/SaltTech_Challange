import React from 'react';
import Navbar from './Components/Navbar';
import Header from './Components/Header';
import Pagination from './Components/Pagination';
import ProductsContainer from './Components/ProductsContainer';
import SearchBar from './Components/SearchBar';

function AppContainer() {
  return (
    <div className="App">
        <Navbar />
        <Header />
        <SearchBar />
        <ProductsContainer />
        <Pagination />
      </div>
  );
}

export default AppContainer;