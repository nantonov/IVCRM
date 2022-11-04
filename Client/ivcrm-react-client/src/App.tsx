import React from 'react';
import Header from './components/header/Header';
import Customer from './components/pages/Customer';
import Order from './components/pages/Order';
import Navigation from './components/navigation/Navigation';
import { NavLink, Link, Route, Routes, BrowserRouter } from 'react-router-dom';
import AppRouter from './components/AppRouter';

const App = () => {

  return (
    <div className="App">
      <Header/>
      {/*
      <Navigation/>
      <main className='app-content-wrapper'>
      <BrowserRouter>
        <Routes>
          <Route path='/customers/*' element={<Customer />}></Route>
          <Route path='/orders/*' element={<Order />}></Route>
          <Route path="*" element={<h2>NotFound</h2>} />
        </Routes>
      </BrowserRouter>
            </main>
 */}
      <BrowserRouter>
                <Navigation/>
                <AppRouter />
            </BrowserRouter>
 

      </div>
  );
}

export default App;
