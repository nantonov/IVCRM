import React from "react";
import Button from "@mui/material/Button";
import Typography from '@mui/material/Typography';
import FormControl from '@mui/material/FormControl';
import { IChangeCustomer } from "../../../models/IChangeCustomer";

interface Props {
  customerId: number
  deleteAction: (x: number) => void
  handleClose: () => void
}

const DeleteCustomerForm: React.FC<Props> = ({customerId, deleteAction, handleClose}) => {

    const handleSubmit = (e : React.MouseEvent<HTMLElement>) => {
      e.preventDefault()
  
      deleteAction(customerId);
      handleClose();
    }

      return (
        <FormControl>
            <Typography variant="h6" fontWeight={700} margin="dense">Delete customer with ID={customerId}?</Typography>
            <div>
            <Button variant="contained" onClick={handleSubmit}>delete</Button>
            <Button variant="contained" onClick={handleClose}>cancel</Button>
            </div>
        </FormControl>
      );
    }
    
    export default DeleteCustomerForm;