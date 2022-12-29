import React, { useState } from "react";
import Button from "@mui/material/Button";
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import FormControl from '@mui/material/FormControl';
import { IProductCategory } from "../../../models/IProductCategory";
import { IChangeProductCategory } from "../../../models/IChangeProductCategory";
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import { updateCategory } from "../../../store/reducers/categories/ActionCreators";
import { ModalActions } from "../../../store/reducers/modal/ModalSlice";

const UpdateCategoryForm = () => {

  const {data} = useAppSelector(state => state.modalReducer)
  var category = data as IProductCategory

  const [changeCategory, setChangeCategory] = useState<IChangeProductCategory>({id: category.id, name: category.name, parentCategoryId: category.parentCategoryId})
  const dispatch = useAppDispatch()

    const handleSubmit = (e: React.MouseEvent<HTMLElement>) => {
        e.preventDefault()
    
        dispatch(updateCategory(changeCategory));
        setChangeCategory({} as IChangeProductCategory);
        dispatch(ModalActions.closeModal());
      }

      return (
        <FormControl>
            <Typography variant="h6" fontWeight={700}>Update product catgory with ID={changeCategory.id}</Typography>
            <TextField 
              value={changeCategory.name} 
              onChange={e => setChangeCategory({...changeCategory, name: e.target.value})} 
              label="First Name" 
              variant="outlined" 
              margin="dense"
              autoComplete='off'
              />

            <Button variant="contained" onClick={handleSubmit}>Save</Button>
        </FormControl>
      );
    }
    
    export default UpdateCategoryForm;