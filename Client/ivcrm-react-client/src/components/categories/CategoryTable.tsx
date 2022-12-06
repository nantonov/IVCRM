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

import UpdateCategoryModal from './modals/UpdateCategoryModal';
import DeleteCategoryModal from './modals/DeleteCategoryModal';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { fetchCategories } from '../../store/reducers/categories/ActionCreators';

const CustomerTable = () => {

  const {categories, isLoading, error} = useAppSelector(state => state.categoryReducer)
  const dispatch = useAppDispatch()

  useEffect(() => {
    dispatch(fetchCategories())
  }, [])

  return (
    <TableContainer component={Paper} >
      <Typography
          sx={{ flex: '1 1 100%' }}
          padding="10px"
          variant="h6"
          component="div"
        >
          Categories
      </Typography>

      {isLoading && <h1>Loading...</h1>}
      {error && <h1>{error}</h1>}

      <hr />
      <Table sx={{ minWidth: 650 }} aria-label="simple table" size='small'>
        <TableHead>
          <TableRow>
            <TableCell>Id</TableCell>
            <TableCell align="right">Name</TableCell>
            <TableCell align="right">Parent category id</TableCell>
            <TableCell align="right"></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {categories.map((row) => (
            <TableRow
              key={row.id}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.id}
              </TableCell>
              <TableCell align="right">{row.name}</TableCell>
              <TableCell align="right">{row.parentCategoryId}</TableCell>
              <TableCell align="right">
              <Stack spacing={0} direction="row">
                <UpdateCategoryModal category={row}/>
                <DeleteCategoryModal categoryId={row.id}/>
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