import React, { useState } from "react";
import Button from "@mui/material/Button";
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import FormControl from '@mui/material/FormControl';
import { IChangeProductCategory } from "../../../models/IChangeProductCategory";
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import { createCategory } from "../../../store/reducers/categories/ActionCreators";
import { IProductCategory } from "../../../models/IProductCategory";
import { ModalActions } from "../../../store/reducers/modal/ModalSlice";

const CreateCategoryForm = () => {

  const {data} = useAppSelector(state => state.modalReducer)
  var parentCategoryId = data as number

    const [category, setCategory] = useState<IChangeProductCategory>({id: 0, name: '', parentCategoryId})
    const dispatch = useAppDispatch()

    const handleSubmit = (e: React.MouseEvent<HTMLElement>) => {
        e.preventDefault()
    
        dispatch(createCategory(category));
        setCategory({} as IProductCategory);
        dispatch(ModalActions.closeModal());
      }

      return (
        <FormControl>
            <Typography variant="h6" fontWeight={700}>Create new product category</Typography>

            <TextField 
                value={category.name} 
                onChange={e => setCategory({...category, name: e.target.value})}  
                label="Category Name" 
                variant="outlined" 
                margin="dense" 
                autoComplete='off'
                />

            <Button variant="contained" onClick={handleSubmit}>Save</Button>
        </FormControl>
      );
    }
    
    export default CreateCategoryForm;