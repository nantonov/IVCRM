import React, { useState } from "react";
import Modal from "@mui/material/Modal";
import Edit from '@mui/icons-material/Edit';
import IconButton from '@mui/material/IconButton';
import style from '../../shared/modal/Modal.module.css';
import UpdateCustomerForm from '../forms/UpdateCustomerForm.jsx';

const UpdateCustomerModal = ({customer, updateAction}) => {
    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);
    
      return (
        <div>
        <IconButton onClick={handleOpen} color="primary" component="label">
          <Edit />
        </IconButton>

        <Modal
            aria-labelledby="simple-modal-title"
            aria-describedby="simple-modal-description"
            open={open}
            onClose={handleClose}
        >
        <div className={style.modal}>
          <UpdateCustomerForm customer={customer} updateAction={updateAction} handleClose={handleClose}/>
        </div>
      </Modal>
      </div>
      );
    }
    
    export default UpdateCustomerModal;