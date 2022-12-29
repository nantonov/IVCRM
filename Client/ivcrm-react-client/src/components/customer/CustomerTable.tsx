import React, { useEffect } from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Typography from '@mui/material/Typography';
import Paper from '@mui/material/Paper';
import Stack from '@mui/material/Stack';

import UpdateCustomerModal from './modals/UpdateCustomerModal';
import DeleteCustomerModal from './modals/DeleteCustomerModal';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { fetchCustomers } from '../../store/reducers/customers/ActionCreators';

const CustomerTable = () => {

  const {customer, customers, isLoading, error} = useAppSelector(state => state.customerReducer)
  const dispatch = useAppDispatch()

  useEffect(() => {
    dispatch(fetchCustomers())
  }, [])

  return (
    <TableContainer component={Paper} >
      <Typography
          sx={{ flex: '1 1 100%' }}
          padding="10px"
          variant="h6"
          component="div"
        >
          Customers
      </Typography>

      {isLoading && <h1>Loading...</h1>}
      {error && <h1>{error}</h1>}

      <hr />
      <Table sx={{ minWidth: 650 }} aria-label="simple table" size='small'>
        <TableHead>
          <TableRow>
            <TableCell>Id</TableCell>
            <TableCell align="right">FullName</TableCell>
            <TableCell align="right">PhoneNumber</TableCell>
            <TableCell align="right">Email</TableCell>
            <TableCell align="right"></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {customers.map((row) => (
            <TableRow
              key={row.id}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.id}
              </TableCell>
              <TableCell align="right">{row.fullName}</TableCell>
              <TableCell align="right">{row.phoneNumber}</TableCell>
              <TableCell align="right">{row.email}</TableCell>
              <TableCell align="right">
              <Stack spacing={0} direction="row">
                <UpdateCustomerModal customer={row}/>
                <DeleteCustomerModal customerId={row.id}/>
                </Stack>
                </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}

export default CustomerTable;