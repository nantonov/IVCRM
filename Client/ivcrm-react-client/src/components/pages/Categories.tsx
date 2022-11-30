import CustomerTable from '../customer/CustomerTable';
import CreateCustomer from '../customer/modals/CreateCustomerModal';
import Stack from '@mui/material/Stack';
import Box from '@mui/material/Box';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import CreateCategoryModal from '../categories/modals/CreateCategoryModal';
import CategoryTable from '../categories/CategoryTable';

function Categories() {
  
  return (
    <Box>
      <Stack padding={2} spacing={2}>
        <CreateCategoryModal/>
        <CategoryTable/>
      </Stack>
    </Box>
  );
}

export default Categories;