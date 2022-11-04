import React from 'react';
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
import { ICustomer } from '../../models/ICustomer';
import { IChangeCustomer } from '../../models/IChangeCustomer';

interface Props {
  customers: Array<ICustomer>
  updateAction: (x: IChangeCustomer) => void
  deleteAction: (x: number) => void
}

const CustomerTable: React.FC<Props> = ({customers, updateAction, deleteAction}) => {

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
      <hr />
      <Table sx={{ minWidth: 650 }} aria-label="simple table" size='small'>
        <TableHead>
          <TableRow>
            <TableCell>Id</TableCell>
            <TableCell align="right">FullName</TableCell>
            <TableCell align="right">PhoneNumber</TableCell>
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
              <TableCell align="right">
              <Stack spacing={0} direction="row">
                <UpdateCustomerModal customer={row} updateAction={updateAction}/>
                <DeleteCustomerModal customerId={row.id} deleteAction={deleteAction}/>
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