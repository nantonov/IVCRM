import React, { useState } from "react";
import Modal from "@mui/material/Modal";
import Button from "@mui/material/Button";
import CreateCustomerForm from '../forms/CreateCustomerForm';
import { StyledModalBox } from '../../../styles/Styles';

const CreateCustomerModal = () => {
    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

      return (
        <div>
        <Button variant="outlined" onClick={handleOpen}>Create new Customer</Button>

        <Modal
            aria-labelledby="simple-modal-title"
            aria-describedby="simple-modal-description"
            open={open}
            onClose={handleClose}
        >
          <StyledModalBox>
            <CreateCustomerForm handleClose={handleClose}/>
          </StyledModalBox>
        </Modal>
      </div>
      );
    }
    
    export default CreateCustomerModal;