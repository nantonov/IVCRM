import React from "react";
import Button from "@mui/material/Button";
import Typography from '@mui/material/Typography';
import FormControl from '@mui/material/FormControl';
import Stack from '@mui/material/Stack';
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import { deleteCustomer } from "../../../store/reducers/customers/ActionCreators";
import { ModalActions } from "../../../store/reducers/modal/ModalSlice";

const DeleteCustomerForm = () => {

  const {data} = useAppSelector(state => state.modalReducer)
  var customerId = data as number
  const dispatch = useAppDispatch()
  
    const handleSubmit = (e : React.MouseEvent<HTMLElement>) => {
      e.preventDefault()
  
      dispatch(deleteCustomer(customerId));
      dispatch(ModalActions.closeModal());
    }

      return (
        <FormControl>
            <Typography variant="h6" fontWeight={700} margin="dense">Delete customer with ID={customerId}?</Typography>
            <Stack spacing={2} direction="row">
              <Button variant="contained" onClick={handleSubmit}>delete</Button>
              <Button variant="contained" onClick={() => ModalActions.closeModal()}>cancel</Button>
            </Stack>
        </FormControl>
      );
    }
    
    export default DeleteCustomerForm;