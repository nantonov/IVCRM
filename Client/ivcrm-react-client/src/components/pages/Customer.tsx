import React, { useEffect, useState } from 'react';
import CustomerTable from '../customer/CustomerTable';
import CustomerService from "../../services/CustomerService";
import CreateCustomer from '../customer/modals/CreateCustomerModal';
import { IChangeCustomer } from '../../models/IChangeCustomer';
import { ICustomer } from '../../models/ICustomer';
import Stack from '@mui/material/Stack';
import Box from '@mui/material/Box';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';

function Customer() {
  
  return (
    <Box>
      <Stack padding={2} spacing={2}>
        <CreateCustomer/>
        <CustomerTable/>
      </Stack>
    </Box>
  );
}

export default Customer;