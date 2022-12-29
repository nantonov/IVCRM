import { CardContent, Typography } from "@mui/material";
import { ICustomer } from "../../models/ICustomer";
import { StyledCard } from "../buildingBlocks/StyledComponents";

interface Props {
    customer: ICustomer
}

const CustomerDetails: React.FC<Props> = ({ customer }) => {

return (
<StyledCard>
    <CardContent>
    <Typography variant="h5" component="div">
        Customer info
    </Typography>
    <hr/>
    <Typography variant="body2">
        Id: {customer.id}
    </Typography>
    <Typography variant="body2">
        Name: {customer.fullName}
    </Typography>
    <Typography variant="body2">
        Phonenumber: {customer.phoneNumber}
    </Typography>
    <Typography variant="body2">
        Email: {customer.email}
    </Typography>
    </CardContent>
</StyledCard>
);
}

export default CustomerDetails;