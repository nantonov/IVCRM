import React, { useEffect, useState } from 'react';
import Header from './components/header/Header';
import Navbar from './components/navbar/Navbar';
import { BrowserRouter } from 'react-router-dom';
import AppRouter from './components/AppRouter';
import { AuthProvider } from './components/authorization/AuthProvider';

const App = () => {

  return (
    <div className="App">
      <AuthProvider>
        <Header/>
          <BrowserRouter>
            <Navbar/>
            <AppRouter />
          </BrowserRouter>
      </AuthProvider>

      </div>
  );
}

export default App;
