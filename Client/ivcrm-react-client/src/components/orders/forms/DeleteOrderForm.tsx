import React from "react";
import Button from "@mui/material/Button";
import Typography from '@mui/material/Typography';
import FormControl from '@mui/material/FormControl';
import Stack from '@mui/material/Stack';
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import { ModalActions } from "../../../store/reducers/modal/ModalSlice";
import { deleteOrder } from "../../../store/reducers/orders/ActionCreators";

const DeleteOrderForm = () => {

  const {data} = useAppSelector(state => state.modalReducer)
  var orderId = data as number
  const dispatch = useAppDispatch()

    const handleSubmit = (e : React.MouseEvent<HTMLElement>) => {
      e.preventDefault()
  
      dispatch(deleteOrder(orderId));
      dispatch(ModalActions.closeModal());
    }

      return (
        <FormControl>
            <Typography variant="h6" fontWeight={700} margin="dense">Delete order with ID={orderId}?</Typography>
            <Stack spacing={2} direction="row">
              <Button variant="contained" onClick={handleSubmit}>delete</Button>
              <Button variant="contained" onClick={() => ModalActions.closeModal()}>cancel</Button>
            </Stack>
        </FormControl>
      );
    }
    
    export default DeleteOrderForm;