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
import { fetchProducts } from '../../store/reducers/products/ActionCreators';
import Edit from '@mui/icons-material/Edit';
import Delete from '@mui/icons-material/Delete';
import ModalWrapper from '../buildingBlocks/ModalWrapper';
import UpdateProductForm from './forms/UpdateProductForm';
import DeleteProductForm from './forms/DeleteProductForm';
import { CircularProgress } from '@mui/material';

const ProductTable = () => {

  const {products, isLoading, error} = useAppSelector(state => state.productReducer)
  const dispatch = useAppDispatch()

  useEffect(() => {
    dispatch(fetchProducts())
  }, [])

  return (
    <TableContainer component={Paper} >
      <Typography
          sx={{ flex: '1 1 100%' }}
          padding="10px"
          variant="h6"
          component="div"
        >
          Products
      </Typography>

      {isLoading && <CircularProgress />}
      {error && <h1>{error}</h1>}

      <hr />
      <Table sx={{ minWidth: 650 }} aria-label="simple table" size='small'>
        <TableHead>
          <TableRow>
            <TableCell>Id</TableCell>
            <TableCell align="right">Name</TableCell>
            <TableCell align="right">Price</TableCell>
            <TableCell align="right">Category</TableCell>
            <TableCell align="right"></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {products.map((row) => (
            <TableRow
              key={row.id}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row"> {row.id}</TableCell>
              <TableCell align="right">{row.name}</TableCell>
              <TableCell align="right">{row.price}</TableCell>
              <TableCell align="right">{row.categoryId}</TableCell>
              <TableCell align="right">
                <Stack spacing={0} direction="row">
                  <ModalWrapper icon={<Edit />} data={row}>
                    <UpdateProductForm/>
                  </ModalWrapper>
                  <ModalWrapper icon={<Delete />} data={row.id}>
                    <DeleteProductForm/>
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

export default ProductTable;