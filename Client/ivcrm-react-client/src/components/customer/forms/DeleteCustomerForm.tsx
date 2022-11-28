import React from "react";
import Button from "@mui/material/Button";
import Typography from '@mui/material/Typography';
import FormControl from '@mui/material/FormControl';
import Stack from '@mui/material/Stack';
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import { deleteCustomer } from "../../../store/reducers/customers/ActionCreators";

interface Props {
  customerId: number
  handleClose: () => void
}

const DeleteCustomerForm: React.FC<Props> = ({customerId, handleClose}) => {
  const dispatch = useAppDispatch()
  
    const handleSubmit = (e : React.MouseEvent<HTMLElement>) => {
      e.preventDefault()
  
      dispatch(deleteCustomer(customerId));
      handleClose();
    }

      return (
        <FormControl>
            <Typography variant="h6" fontWeight={700} margin="dense">Delete customer with ID={customerId}?</Typography>
            <Stack spacing={2} direction="row">
              <Button variant="contained" onClick={handleSubmit}>delete</Button>
              <Button variant="contained" onClick={handleClose}>cancel</Button>
            </Stack>
        </FormControl>
      );
    }
    
    export default DeleteCustomerForm;