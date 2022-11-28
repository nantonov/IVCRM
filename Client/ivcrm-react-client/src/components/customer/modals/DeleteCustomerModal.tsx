import React, { useState } from "react";
import Modal from "@mui/material/Modal";
import Delete from '@mui/icons-material/Delete';
import IconButton from '@mui/material/IconButton';
import { StyledModalBox } from '../../../styles/Styles';
import DeleteCustomerForm from '../forms/DeleteCustomerForm';

interface Props {
  customerId: number
}

const DeleteCustomerModal: React.FC<Props> = ({customerId}) => {
    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

      return (
        <div>
        <IconButton onClick={handleOpen} color="error" component="label">
          <Delete />
        </IconButton>

        <Modal
            aria-labelledby="simple-modal-title"
            aria-describedby="simple-modal-description"
            open={open}
            onClose={handleClose}
        >
        <StyledModalBox>
          <DeleteCustomerForm customerId={customerId} handleClose={handleClose}/>
        </StyledModalBox>
      </Modal>
      </div>
      );
    }
    
    export default DeleteCustomerModal;