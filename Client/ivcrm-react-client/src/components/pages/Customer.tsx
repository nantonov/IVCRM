import React, { useEffect, useState } from 'react';
import CustomerTable from '../customer/CustomerTable';
import CustomerService from "../../services/CustomerService";
import CreateCustomer from '../customer/modals/CreateCustomerModal';
import { IChangeCustomer } from '../../models/IChangeCustomer';
import { ICustomer } from '../../models/ICustomer';

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
    <div className="Customer">
      <CreateCustomer createAction={createCustomer}/>
      <CustomerTable customers={customers} updateAction={updateCustomer} deleteAction={deleteCustomer}/>
    </div>
  );
}

export default Customer;