import React, { useState } from "react";
import Modal from "@mui/material/Modal";
import Delete from '@mui/icons-material/Delete';
import IconButton from '@mui/material/IconButton';
import style from '../../shared/modal/Modal.module.css';
import DeleteCustomerForm from '../forms/DeleteCustomerForm.jsx';

const DeleteCustomerModal = ({customerId, deleteAction}) => {
    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

      return (
        <div>
        <IconButton onClick={handleOpen} color="primary" component="label">
          <Delete />
        </IconButton>

        <Modal
            aria-labelledby="simple-modal-title"
            aria-describedby="simple-modal-description"
            open={open}
            onClose={handleClose}
        >
        <div className={style.modal}>
          <DeleteCustomerForm customerId={customerId} deleteAction={deleteAction} handleClose={handleClose}/>
        </div>
      </Modal>
      </div>
      );
    }
    
    export default DeleteCustomerModal;