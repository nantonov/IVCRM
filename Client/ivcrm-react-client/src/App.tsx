import React, { useEffect, useState } from 'react';
import Header from './components/header/Header';
import Navbar from './components/navbar/Navbar';
import { BrowserRouter } from 'react-router-dom';
import AppRouter from './router/AppRouter';

const App = () => {

  return (
    <div className="App">
        <Header/>
          <BrowserRouter>
            <Navbar/>
            <AppRouter />
          </BrowserRouter>
      </div>
  );
}

export default App;
