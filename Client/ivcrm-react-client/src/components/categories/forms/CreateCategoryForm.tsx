import React, { useState } from "react";
import Button from "@mui/material/Button";
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import FormControl from '@mui/material/FormControl';
import { IChangeProductCategory } from "../../../models/IChangeProductCategory";

interface Props {
    parentCategory?: number
    createAction: (x: IChangeProductCategory) => void
    handleClose: () => void
}

const CreateCategoryForm: React.FC<Props> = ({parentCategory, createAction, handleClose}) => {

    const [category, setCategory] = useState<IChangeProductCategory>({id: 0, name: '', parentCategoryId: parentCategory})

    const handleSubmit = (e: React.MouseEvent<HTMLElement>) => {
        e.preventDefault()
    
        createAction(category);
        setCategory({id: 0, name: '', parentCategoryId: 0});
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