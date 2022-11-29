import React from "react";
import Button from "@mui/material/Button";
import Typography from '@mui/material/Typography';
import FormControl from '@mui/material/FormControl';
import Stack from '@mui/material/Stack';
import { useAppDispatch } from "../../../hooks/redux";
import { deleteCategory } from "../../../store/reducers/categories/ActionCreators";

interface Props {
  categoryId: number
  handleClose: () => void
}

const DeleteCategoryForm: React.FC<Props> = ({categoryId, handleClose}) => {
const dispatch = useAppDispatch()

    const handleSubmit = (e : React.MouseEvent<HTMLElement>) => {
      e.preventDefault()
  
      dispatch(deleteCategory(categoryId));
      handleClose();
    }

      return (
        <FormControl>
            <Typography variant="h6" fontWeight={700} margin="dense">Delete category with ID={categoryId}?</Typography>
            <Stack spacing={2} direction="row">
              <Button variant="contained" onClick={handleSubmit}>delete</Button>
              <Button variant="contained" onClick={handleClose}>cancel</Button>
            </Stack>
        </FormControl>
      );
    }
    
    export default DeleteCategoryForm;