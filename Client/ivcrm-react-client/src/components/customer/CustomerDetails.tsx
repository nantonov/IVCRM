import { ICustomer } from "../../models/ICustomer";

interface Props {
    customer: ICustomer
}

const CustomerDetails: React.FC<Props> = ({ customer }) => {

return (
<div>
    <h1>Customer Info</h1>
    <p>{customer.id}</p>
    <p>{customer.fullName}</p>
    <p>{customer.phoneNumber}</p>
</div>
);
}

export default CustomerDetails;