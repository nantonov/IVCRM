import Stack from '@mui/material/Stack';
import Box from '@mui/material/Box';
import CategoryTable from '../categories/CategoryTable';
import ModalWrapper from '../buildingBlocks/ModalWrapper';
import { Add } from '@mui/icons-material';
import CreateCategoryForm from '../categories/forms/CreateCategoryForm';

function CategoriesPage() {
  
  return (
    <Box>
      <Stack padding={2} spacing={2}>
      <ModalWrapper icon={<Add />}>
            <CreateCategoryForm/>
        </ModalWrapper>
        <CategoryTable/>
      </Stack>
    </Box>
  );
}

export default CategoriesPage;