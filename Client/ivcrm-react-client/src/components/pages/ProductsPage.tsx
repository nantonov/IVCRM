import { Divider, Grid } from '@mui/material';
import ModalWrapper from '../buildingBlocks/ModalWrapper';
import ProductTable from '../products/ProductsTable';
import Add from '@mui/icons-material/Add';
import CreateProductForm from '../products/forms/CreateProductForm';

function ProductsPage() {
  return (
    <Grid direction='row' container spacing={1}>
    <Grid container item sm={3}>
        filters...
    </Grid>
    <Divider orientation="vertical" flexItem/>
    <Grid container item sm={9}>
        <ModalWrapper icon={<Add />}>
            <CreateProductForm/>
        </ModalWrapper>
    <ProductTable/>
    </Grid>
  </Grid>
  );
}

export default ProductsPage;