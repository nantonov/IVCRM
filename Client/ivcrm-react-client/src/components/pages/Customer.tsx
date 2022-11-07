import React, { useEffect, useState } from 'react';
import CustomerTable from '../customer/CustomerTable';
import CustomerService from "../../services/customerService";
import CreateCustomer from '../customer/modals/CreateCustomerModal';
import { IChangeCustomer } from '../../models/IChangeCustomer';
import { ICustomer } from '../../models/ICustomer';
import Stack from '@mui/material/Stack';
import Box from '@mui/material/Box';

function Customer() {
  const [customers, setCustomers] = useState<Array<ICustomer>>([])

  useEffect(() => {
    fetchCustomers()
  }, [])

  async function createCustomer(customer: IChangeCustomer) {
    const createdCustomer = await CustomerService.create(customer);
    setCustomers([...customers, createdCustomer])
  }

  async function fetchCustomers() {
    const customers = await CustomerService.getAll();
    setCustomers(customers)
  }

  async function updateCustomer(customer: IChangeCustomer) {
    const updatedCustomer = await CustomerService.update(customer);
    setCustomers({...customers, [updatedCustomer.id]: updatedCustomer})
  }

  async function deleteCustomer(id: number) {
    await CustomerService.delete(id);
    setCustomers(customers.filter(x => x.id !== id))
  }

  return (
    <Box>
      <Stack padding={2} spacing={2}>
        <CreateCustomer createAction={createCustomer}/>
        <CustomerTable customers={customers} updateAction={updateCustomer} deleteAction={deleteCustomer}/>
      </Stack>
    </Box>
  );
}

export default Customer;