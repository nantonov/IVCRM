import React, { useState } from "react";
import Modal from "@mui/material/Modal";
import Button from "@mui/material/Button";
import CreateCustomerForm from '../forms/CreateCustomerForm.jsx';
import style from '../../shared/modal/Modal.module.css';

const CreateCustomerModal = ({createAction}) => {
    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

      return (
        <div>
        <Button onClick={handleOpen}>Create new Customer</Button>

        <Modal
            aria-labelledby="simple-modal-title"
            aria-describedby="simple-modal-description"
            open={open}
            onClose={handleClose}
        >
          <div className={style.modal}>
            <CreateCustomerForm createAction={createAction} handleClose={handleClose}/>
          </div>
        </Modal>
      </div>
      );
    }
    
    export default CreateCustomerModal;