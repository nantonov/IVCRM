import Box from '@mui/material/Box';
import Button from '@mui/material/Button';

import React, { useEffect, useState } from 'react';
import Header from './components/header/Header';
import CustomerTable from './components/customer/CustomerTable';
import CustomerService from "./services/CustomerService";
import CreateCustomer from './components/customer/CreateCustomer';
import Customer from './components/customer/Customer';

const App = () => {

  return (
    <div className="App">
      <Header/>
      <Customer/>
      </div>
  );
}

export default App;
