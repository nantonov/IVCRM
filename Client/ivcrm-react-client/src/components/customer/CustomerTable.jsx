import React, { useEffect, useState } from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import classes from './CustomerTable.module.css';

import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Modal from '@mui/material/Modal';
import UpdateCustomer from './UpdateCustomerModal';
import DeleteCustomer from './DeleteCustomerModal';

const CustomerTable = ({customers, updateCustomer, deleteCustomer}) => {

  return (
    <div className={classes.table}>
    <TableContainer component={Paper} >
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Dessert (100g serving)</TableCell>
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
                <UpdateCustomer update={updateCustomer}/>
                <DeleteCustomer deleteCustomer={deleteCustomer} rowId={row.id}/>
                </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
    </div>
  );
}

export default CustomerTable;