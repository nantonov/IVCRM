import React, { useState } from "react";
import Button from "@mui/material/Button";
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import FormControl from '@mui/material/FormControl';
import { useAppDispatch } from "../../../hooks/redux";
import { IChangeProduct } from "../../../models/IChangeProduct";
import { IProduct } from "../../../models/IProduct";
import { createProduct } from "../../../store/reducers/products/ActionCreators";
import { ModalActions } from "../../../store/reducers/modal/ModalSlice";

const CreateProductForm = () => {

    const [product, setCategory] = useState<IChangeProduct>({} as IChangeProduct)
    const dispatch = useAppDispatch()

    const handleSubmit = (e: React.MouseEvent<HTMLElement>) => {
        e.preventDefault()
    
        dispatch(createProduct(product));
        setCategory({} as IProduct);
        dispatch(ModalActions.closeModal());
      }

      return (
        <FormControl>
            <Typography variant="h6" fontWeight={700}>Create new product category</Typography>

            <TextField 
                value={product.name} 
                onChange={e => setCategory({...product, name: e.target.value})}  
                label="Product Name" 
                variant="outlined" 
                margin="dense" 
                autoComplete='off'
                />
            <TextField 
                value={product.price} 
                onChange={e => setCategory({...product, price: Number(e.target.value)})}  
                label="Price" 
                variant="outlined" 
                margin="dense" 
                autoComplete='off'
                />
            <TextField 
                value={product.categoryId} 
                onChange={e => setCategory({...product, categoryId: Number(e.target.value)})}  
                label="Category" 
                variant="outlined" 
                margin="dense" 
                autoComplete='off'
                />

            <Button variant="contained" onClick={handleSubmit}>Save</Button>
        </FormControl>
      );
    }
    
    export default CreateProductForm;