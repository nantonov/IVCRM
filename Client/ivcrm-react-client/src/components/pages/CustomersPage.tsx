import CustomerTable from '../customer/CustomerTable';
import Stack from '@mui/material/Stack';
import Box from '@mui/material/Box';
import ModalWrapper from '../buildingBlocks/ModalWrapper';
import { Add } from '@mui/icons-material';
import CreateCustomerForm from '../customer/forms/CreateCustomerForm';

function CustomersPage() {
  
  return (
    <Box>
      <Stack padding={2} spacing={2}>
      <ModalWrapper icon={<Add />}>
            <CreateCustomerForm/>
        </ModalWrapper>
        <CustomerTable/>
      </Stack>
    </Box>
  );
}

export default CustomersPage;