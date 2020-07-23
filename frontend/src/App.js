import React from 'react';
import Navbar from './Components/Navbar';
import Header from './Components/Header';
import ProductsContainer from './Components/ProductsContainer';

function App() {
  return (
    <div className="App">
      <Navbar />
      <Header />
      <ProductsContainer />
    </div>
  );
}

export default App;