import React, { useState } from "react";
import Modal from "@mui/material/Modal";
import Edit from '@mui/icons-material/Edit';
import IconButton from '@mui/material/IconButton';
import { StyledModalBox } from '../../../styles/Styles';
import UpdateCustomerForm from '../forms/UpdateCategoryForm';
import { IChangeProductCategory } from "../../../models/IChangeProductCategory";
import { IProductCategory } from "../../../models/IProductCategory";

interface Props {
  category: IProductCategory
}

const UpdateCategoryModal: React.FC<Props> = ({category}) => {
    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);
    
      return (
        <div>
        <IconButton onClick={handleOpen} color="primary" component="label" size="small">
          <Edit />
        </IconButton>

        <Modal
            aria-labelledby="simple-modal-title"
            aria-describedby="simple-modal-description"
            open={open}
            onClose={handleClose}
        >
        <StyledModalBox>
          <UpdateCustomerForm category={category} handleClose={handleClose}/>
        </StyledModalBox>
      </Modal>
      </div>
      );
    }
    
    export default UpdateCategoryModal;