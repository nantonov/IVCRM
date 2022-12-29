import OrderDetails from '../orders/OrderDetails';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { useParams } from 'react-router-dom';
import { useEffect } from 'react';
import { getOrderById } from '../../store/reducers/orders/ActionCreators';
import { getCustomerById } from '../../store/reducers/customers/ActionCreators';
import CustomerDetails from '../customer/CustomerDetails';
import { Grid } from '@mui/material';

const OrderDetailsPage = () => {

  const {order, isLoading, error} = useAppSelector(state => state.orderReducer)
  const {customer} = useAppSelector(state => state.customerReducer)
  const dispatch = useAppDispatch()
  const params = useParams();
  
  var orderId = 0;

if (typeof(params.orderId) !== 'undefined' && params.orderId != null) {
  orderId = parseInt(params.orderId, 10);
}

useEffect(() => {
  dispatch(getOrderById(orderId))
  dispatch(getCustomerById(order.customerId))
}, [])

  return (
    <Grid container spacing={2} alignItems="stretch">
      <Grid item style={{display: "flex"}} xs={12} sm={12} md={6} lg={6} xl={6}>
        <OrderDetails order={order}/>
      </Grid>
      <Grid item style={{display: "flex"}} xs={12} sm={12} md={6} lg={6} xl={6}>
        <CustomerDetails customer={customer}/>
      </Grid>
    </Grid>
  );
}

export default OrderDetailsPage;
