import { Divider, Grid } from '@mui/material';
import ModalWrapper from '../buildingBlocks/ModalWrapper';
import { Add } from '@mui/icons-material';
import CreateOrderForm from '../orders/forms/CreateOrderForm';
import OrderTable from '../orders/OrderTable';

function Order() {


  return (
    <Grid direction='row' container spacing={1}>
    <Grid container item sm={3}>
        filters...
    </Grid>
    <Divider orientation="vertical" flexItem/>
    <Grid container item sm={9}>
        <ModalWrapper icon={<Add />}>
            <CreateOrderForm/>
        </ModalWrapper>
    <OrderTable/>
    </Grid>
  </Grid>
  );
}

export default Order;