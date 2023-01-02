import React, { useState } from "react";
import Button from "@mui/material/Button";
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import FormControl from '@mui/material/FormControl';
import { useAppDispatch } from "../../../hooks/redux";
import { IChangeOrder } from "../../../models/IChangeOrder";
import { IOrder } from "../../../models/IOrder";
import { createOrder } from "../../../store/reducers/orders/ActionCreators";
import { ModalActions } from "../../../store/reducers/modal/ModalSlice";

const CreateOrderForm = () => {

    const [order, setOrder] = useState<IChangeOrder>({} as IChangeOrder)
    const dispatch = useAppDispatch()

    const handleSubmit = (e: React.MouseEvent<HTMLElement>) => {
        e.preventDefault()
    
        dispatch(createOrder(order));
        setOrder({} as IOrder);
        dispatch(ModalActions.closeModal());
      }

      return (
        <FormControl>
            <Typography variant="h6" fontWeight={700}>Create new order</Typography>

            <TextField 
                value={order.name} 
                onChange={e => setOrder({...order, name: e.target.value})}  
                label="Product Name" 
                variant="outlined" 
                margin="dense" 
                autoComplete='off'
                />
            <TextField 
                value={order.name} 
                onChange={e => setOrder({...order, name: e.target.value})}  
                label="Price" 
                variant="outlined" 
                margin="dense" 
                autoComplete='off'
                />

            <Button variant="contained" onClick={handleSubmit}>Save</Button>
        </FormControl>
      );
    }
    
    export default CreateOrderForm;