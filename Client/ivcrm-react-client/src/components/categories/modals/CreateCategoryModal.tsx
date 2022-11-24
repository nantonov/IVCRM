import React, { useState } from "react";
import Modal from "@mui/material/Modal";
import CreateCategoryForm from '../forms/CreateCategoryForm';
import { StyledModalBox } from '../../../styles/Styles';

import Add from '@mui/icons-material/Add';
import { IChangeProductCategory } from "../../../models/IChangeProductCategory";
import { IconButton } from "@mui/material";

interface Props {
  parentCategory?: number
  createAction: (x: IChangeProductCategory) => void
}

const CreateCategoryModal: React.FC<Props> = ({parentCategory, createAction}) => {
    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

      return (
        <div>
        <IconButton onClick={handleOpen} color="success" component="label">
          <Add />
        </IconButton>

        <Modal
            aria-labelledby="simple-modal-title"
            aria-describedby="simple-modal-description"
            open={open}
            onClose={handleClose}
        >
          <StyledModalBox>
            <CreateCategoryForm parentCategory={parentCategory} createAction={createAction} handleClose={handleClose}/>
          </StyledModalBox>
        </Modal>
      </div>
      );
    }
    
    export default CreateCategoryModal;