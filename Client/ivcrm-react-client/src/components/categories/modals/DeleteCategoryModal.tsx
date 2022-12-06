import React, { useState } from "react";
import Modal from "@mui/material/Modal";
import Delete from '@mui/icons-material/Delete';
import IconButton from '@mui/material/IconButton';
import { StyledModalBox } from '../../../styles/Styles';
import DeleteCategoryForm from '../forms/DeleteCategoryForm';

interface Props {
  categoryId: number
}

const DeleteCustomerModal: React.FC<Props> = ({categoryId}) => {
    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

      return (
        <div>
        <IconButton onClick={handleOpen} color="error" component="label" size="small">
          <Delete />
        </IconButton>

        <Modal
            aria-labelledby="simple-modal-title"
            aria-describedby="simple-modal-description"
            open={open}
            onClose={handleClose}
        >
        <StyledModalBox>
          <DeleteCategoryForm categoryId={categoryId} handleClose={handleClose}/>
        </StyledModalBox>
      </Modal>
      </div>
      );
    }
    
    export default DeleteCustomerModal;