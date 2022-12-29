import { IOrder } from "../../models/IOrder";

interface Props {
    order: IOrder
}

const OrderDetails: React.FC<Props> = ({ order }) => {

return (
<div>
<h1>Order Info</h1>
    <p>{order.id}</p>
    <p>{order.orderStatus}</p>
    <p>{order.orderDate}</p>
    <p>{order.name}</p>
    <p>{order.customerId}</p>
</div>
);
}

export default OrderDetails;