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
import { fetchOrders } from '../../store/reducers/orders/ActionCreators';
import ModalWrapper from '../buildingBlocks/ModalWrapper';
import Edit from '@mui/icons-material/Edit';
import Delete from '@mui/icons-material/Delete';
import UpdateOrderForm from './forms/UpdateOrderForm';
import DeleteOrderForm from './forms/DeleteOrderForm';
import { useNavigate } from 'react-router-dom';
import { CircularProgress } from '@mui/material';

const OrderTable = () => {

  const {orders, isLoading, error} = useAppSelector(state => state.orderReducer)
  const dispatch = useAppDispatch()
  const navigate = useNavigate();

  useEffect(() => {
    dispatch(fetchOrders())
  }, [])

  const handleClick = (event: React.MouseEvent<unknown>, id: number) => {
    navigate(`/orders/${id}`)
  }

  return (
    <TableContainer component={Paper} >
      <Typography
          sx={{ flex: '1 1 100%' }}
          padding="10px"
          variant="h6"
          component="div"
        >
          Orders
      </Typography>

      {isLoading && <CircularProgress />}
      {error && <h1>{error}</h1>}

      <hr />
      <Table sx={{ minWidth: 650 }} aria-label="simple table" size='small'>
        <TableHead>
          <TableRow>
            <TableCell>Id</TableCell>
            <TableCell align="right">Name</TableCell>
            <TableCell align="right">CustomerId</TableCell>
            <TableCell align="right"></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {orders.map((row) => (
            <TableRow
              onClick={(event) => handleClick(event, row.id)}
              key={row.id}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.id}
              </TableCell>
              <TableCell align="right">{row.name}</TableCell>
              <TableCell align="right">{row.customerId}</TableCell>
              <TableCell align="right">
              <Stack spacing={0} direction="row">
              <ModalWrapper icon={<Edit />} data={row}>
                    <UpdateOrderForm/>
                  </ModalWrapper>
                  <ModalWrapper icon={<Delete />} data={row.id}>
                    <DeleteOrderForm/>
                  </ModalWrapper>
                </Stack>
                </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}

export default OrderTable;