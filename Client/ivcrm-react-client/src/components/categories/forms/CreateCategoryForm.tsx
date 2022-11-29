import React, { useState } from "react";
import Button from "@mui/material/Button";
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import FormControl from '@mui/material/FormControl';
import { IChangeProductCategory } from "../../../models/IChangeProductCategory";
import { useAppDispatch } from "../../../hooks/redux";
import { createCategory } from "../../../store/reducers/categories/ActionCreators";

interface Props {
    parentCategoryId?: number
    handleClose: () => void
}

const CreateCategoryForm: React.FC<Props> = ({ parentCategoryId, handleClose}) => {

    const [category, setCategory] = useState<IChangeProductCategory>({id: 0, name: '', parentCategoryId})
    const dispatch = useAppDispatch()

    const handleSubmit = (e: React.MouseEvent<HTMLElement>) => {
        e.preventDefault()
    
        dispatch(createCategory(category));
        setCategory({} as IProductCategory);
        handleClose();
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