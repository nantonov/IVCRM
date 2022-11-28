import React, { useState } from "react";
import Modal from "@mui/material/Modal";
import Edit from '@mui/icons-material/Edit';
import IconButton from '@mui/material/IconButton';
import { StyledModalBox } from '../../../styles/Styles';
import UpdateCustomerForm from '../forms/UpdateCustomerForm';
import { IChangeCustomer } from "../../../models/IChangeCustomer";
import { ICustomer } from "../../../models/ICustomer";

interface Props {
  customer: ICustomer
}

const UpdateCustomerModal: React.FC<Props> = ({customer}) => {
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
        <StyledModalBox>
          <UpdateCustomerForm customer={customer} handleClose={handleClose}/>
        </StyledModalBox>
      </Modal>
      </div>
      );
    }
    
    export default UpdateCustomerModal;