import React, { useEffect, useState } from 'react';
import CustomerTable from './CustomerTable';
import CustomerService from "../../services/CustomerService";
import CreateCustomer from './modals/CreateCustomerModal';

function Customer() {
  const [customers, setCustomers] = useState([])

  useEffect(() => {
    fetchCustomers()
  }, [])

  async function createCustomer(newCustomer) {
    const createdCustomer = await CustomerService.create(newCustomer);
    setCustomers([...customers, createdCustomer])
  }

  async function fetchCustomers() {
    const customers = await CustomerService.getAll();
    setCustomers(customers)
  }

  async function updateCustomer(updateCustomerRequest) {
    const updatedCustomer = await CustomerService.update(updateCustomerRequest);
    setCustomers({...customers, [updatedCustomer.id]: updatedCustomer})
  }

  async function deleteCustomer(id) {
    await CustomerService.delete(id);
    setCustomers(customers.filter(x => x.id !== id))
  }

  return (
    <div className="Customer">
      <CreateCustomer createAction={createCustomer}/>
      <CustomerTable customers={customers} updateAction={updateCustomer} deleteAction={deleteCustomer}/>
    </div>
  );
}

export default Customer;