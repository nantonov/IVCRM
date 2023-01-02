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
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { fetchCustomers } from '../../store/reducers/customers/ActionCreators';
import { Box, CircularProgress, TablePagination } from '@mui/material';
import ModalWrapper from '../buildingBlocks/ModalWrapper';
import { Delete, Edit } from '@mui/icons-material';
import UpdateCustomerForm from './forms/UpdateCustomerForm';
import DeleteCustomerForm from './forms/DeleteCustomerForm';


const CustomerTable = () => {

  const {paginationData, customers, isLoading, error} = useAppSelector(state => state.customerReducer)
  const dispatch = useAppDispatch()

  const handlePageChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    var pageSize = (parseInt(event.target.value, 10))
    dispatch(fetchCustomers({ pageNumber: paginationData.currentPage, pageSize: pageSize}))
  };

  const handlePageSizeChange = (event: unknown, newPage: number) => {
    dispatch(fetchCustomers({ pageNumber: newPage, pageSize: paginationData.pageSize}))
  };

  useEffect(() => {
    dispatch(fetchCustomers({ pageNumber: paginationData.currentPage, pageSize: paginationData.pageSize}))
  }, [])

  return (
    <Box sx={{ width: '100%' }}>
    <TableContainer component={Paper} >
      <Typography
          sx={{ flex: '1 1 100%' }}
          padding="10px"
          variant="h6"
          component="div"
        >
          Customers
      </Typography>

      {isLoading && <CircularProgress />}
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
                  <ModalWrapper icon={<Edit />} data={row}>
                    <UpdateCustomerForm/>
                  </ModalWrapper>
                  <ModalWrapper icon={<Delete />} data={row.id}>
                    <DeleteCustomerForm/>
                  </ModalWrapper>
                </Stack>
                </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
            <TablePagination
            rowsPerPageOptions={[5, 10, 25]}
            component="div"
            count={paginationData.totalCount}
            rowsPerPage={paginationData.pageSize}
            page={paginationData.currentPage}
            onPageChange={handlePageSizeChange}
            onRowsPerPageChange={handlePageChange}
          />
    </Box>
  );
}

export default CustomerTable;