import React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Typography from '@mui/material/Typography';
import Paper from '@mui/material/Paper';
import { useNavigate } from 'react-router-dom';
import { IOrderItem } from '../../models/IOrderItem';
import Avatar from '@mui/material/Avatar';


interface Props {
  orderItems: IOrderItem[]
}

const OrderItemTable: React.FC<Props> = ({ orderItems }) => {
  const navigate = useNavigate();

  const redirectOnProductClick = (event: React.MouseEvent<unknown>, id: number) => {
    navigate(`/products/${id}`)
  }

  if (!orderItems || orderItems.length === 0) {
    return <h1>No data...</h1>;
  }

  return (
    <TableContainer component={Paper} >
      <Typography
          sx={{ flex: '1 1 100%' }}
          padding="10px"
          variant="h6"
          component="div"
        >
          OrderItems
      </Typography>

      <hr />
      <Table sx={{ minWidth: 650 }} aria-label="simple table" size='small'>
        <TableHead>
          <TableRow>
            <TableCell></TableCell>
            <TableCell>Id</TableCell>
            <TableCell align="right">Name</TableCell>
            <TableCell align="right">Quantity</TableCell>
            <TableCell align="right">Price</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {orderItems.map((row) => (
            <TableRow
              onClick={(event) => redirectOnProductClick(event, row.productId)}
              key={row.productId}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                <Avatar variant="square" alt="Remy Sharp" src={row.product.pictureUri} >O</Avatar>
              </TableCell>
              <TableCell component="th" scope="row">
                {row.productId}
              </TableCell>
              <TableCell align="right">{row.product.name}</TableCell>
              <TableCell align="right">{row.quantity}</TableCell>
              <TableCell align="right">{row.price}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}

export default OrderItemTable;