import OrderDetails from '../orders/OrderDetails';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { useParams } from 'react-router-dom';
import { useEffect } from 'react';
import { getOrderById } from '../../store/reducers/orders/ActionCreators';
import { getCustomerById } from '../../store/reducers/customers/ActionCreators';
import CustomerDetails from '../customer/CustomerDetails';

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
    <div>
      <OrderDetails order={order}/>
      <CustomerDetails customer={customer}/>
    </div>
  );
}

export default OrderDetailsPage;
