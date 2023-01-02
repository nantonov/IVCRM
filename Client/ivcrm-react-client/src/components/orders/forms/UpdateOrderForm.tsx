import React, { useState } from "react";
import Button from "@mui/material/Button";
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import FormControl from '@mui/material/FormControl';
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import { ModalActions } from "../../../store/reducers/modal/ModalSlice";
import { IChangeOrder } from "../../../models/IChangeOrder";
import { IOrder } from "../../../models/IOrder";
import { updateOrder } from "../../../store/reducers/orders/ActionCreators";

const UpdateOrderForm = () => {

  const {data} = useAppSelector(state => state.modalReducer)
  var order = data as IOrder
  
  const [changeOrder, setChangeOrder] = useState<IChangeOrder>({id: order.id, name: order.name, orderStatus: order.orderStatus, orderDate: order.orderDate, customerId: order.customerId})
  const dispatch = useAppDispatch()

    const handleSubmit = (e: React.MouseEvent<HTMLElement>) => {
        e.preventDefault()
    
        dispatch(updateOrder(changeOrder));
        setChangeOrder({} as IChangeOrder);
        dispatch(ModalActions.closeModal());
      }

      return (
        <FormControl>
          <Typography variant="h6" fontWeight={700}>Update product catgory with ID={changeOrder.id}</Typography>
            <TextField 
              value={changeOrder.name} 
              onChange={e => setChangeOrder({...changeOrder, name: e.target.value})} 
              label="Name" 
              variant="outlined" 
              margin="dense"
              autoComplete='off'
              />

            <Button variant="contained" onClick={handleSubmit}>Save</Button>
        </FormControl>
      );
    }
    
    export default UpdateOrderForm;