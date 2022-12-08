import CustomerTable from '../customer/CustomerTable';
import CreateCustomer from '../customer/modals/CreateCustomerModal';
import Stack from '@mui/material/Stack';
import Box from '@mui/material/Box';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';

function Customer() {
  
  return (
    <Box>
      <Stack padding={2} spacing={2}>
        <CreateCustomer/>
        <CustomerTable/>
      </Stack>
    </Box>
  );
}

export default Customer;