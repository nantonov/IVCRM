import React, { useState } from "react";
import Button from "@mui/material/Button";
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import FormControl from '@mui/material/FormControl';
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import { ModalActions } from "../../../store/reducers/modal/ModalSlice";
import { IChangeProduct } from "../../../models/IChangeProduct";
import { IProduct } from "../../../models/IProduct";
import { updateProduct } from "../../../store/reducers/products/ActionCreators";

const UpdateProductForm = () => {

  const {data} = useAppSelector(state => state.modalReducer)
  var product = data as IProduct
  
  const [changeProduct, setChangeProduct] = useState<IChangeProduct>({id: product.id, name: product.name, price: product.price, categoryId: product.categoryId})
  const dispatch = useAppDispatch()

    const handleSubmit = (e: React.MouseEvent<HTMLElement>) => {
        e.preventDefault()
    
        dispatch(updateProduct(changeProduct));
        setChangeProduct({} as IChangeProduct);
        dispatch(ModalActions.closeModal());
      }

      return (
        <FormControl>
          <Typography variant="h6" fontWeight={700}>Update product catgory with ID={changeProduct.id}</Typography>
            <TextField 
              value={changeProduct.name} 
              onChange={e => setChangeProduct({...changeProduct, name: e.target.value})} 
              label="Name" 
              variant="outlined" 
              margin="dense"
              autoComplete='off'
              />
          <TextField 
              value={changeProduct.price} 
              onChange={e => setChangeProduct({...changeProduct, price: Number(e.target.value)})} 
              label="Price" 
              variant="outlined" 
              margin="dense"
              autoComplete='off'
              />
          <TextField 
              value={changeProduct.categoryId} 
              onChange={e => setChangeProduct({...changeProduct, categoryId: Number(e.target.value)})} 
              label="Category" 
              variant="outlined" 
              margin="dense"
              autoComplete='off'
              />

            <Button variant="contained" onClick={handleSubmit}>Save</Button>
        </FormControl>
      );
    }
    
    export default UpdateProductForm;