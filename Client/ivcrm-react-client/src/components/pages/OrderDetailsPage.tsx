import OrderDetails from '../orders/OrderDetails';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { useParams } from 'react-router-dom';
import { useEffect } from 'react';
import { getOrderById } from '../../store/reducers/orders/ActionCreators';
import CustomerDetails from '../customer/CustomerDetails';
import { Grid } from '@mui/material';
import OrderItemTable from '../orderItems/OrderItemTable';

const OrderDetailsPage = () => {

  const {order} = useAppSelector(state => state.orderReducer)
  const params = useParams();
  const dispatch = useAppDispatch()
  
  var orderId = 0;
if (typeof(params.orderId) !== 'undefined' && params.orderId != null) {
  orderId = parseInt(params.orderId, 10);
}

useEffect(() => {
  dispatch(getOrderById(orderId))
}, [])

  return (
    <Grid container spacing={2} alignItems="stretch">
      <Grid item style={{display: "flex"}} xs={12} sm={12} md={6} lg={6} xl={6}>
        <OrderDetails order={order}/>
      </Grid>
      <Grid item style={{display: "flex"}} xs={12} sm={12} md={6} lg={6} xl={6}>
        <CustomerDetails customer={order.customer}/>
      </Grid>
      <Grid item style={{display: "flex"}} xs={12}>
        <OrderItemTable orderItems={order.orderItems}/>
      </Grid>
    </Grid>
  );
}

export default OrderDetailsPage;
