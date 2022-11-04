import React from "react";
import Button from "@mui/material/Button";
import Typography from '@mui/material/Typography';
import FormControl from '@mui/material/FormControl';

const DeleteCustomerForm = ({customerId, deleteAction, handleClose}) => {

    const handleSubmit = (e) => {
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