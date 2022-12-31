import React, { ReactElement, useState } from "react";
import Modal from "@mui/material/Modal";
import IconButton from '@mui/material/IconButton';
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { ModalActions } from "../../store/reducers/modal/ModalSlice";
import { StyledModalBox } from "./StyledComponents";

interface Props {
  data?: any
  icon: React.ReactNode;
  children: ReactElement<any>;
}

const UpdateCategoryModal: React.FC<Props> = ({data, icon, children}) => {
    const [instanceFlag, setInstanceFlag] = useState(false);
    const {isOpen} = useAppSelector(state => state.modalReducer)
    const dispatch = useAppDispatch()

    const handleOpen = () => 
    {
      dispatch(ModalActions.openModal(data));
      setInstanceFlag(true);
    }

    const handleClose = () => 
    {
      dispatch(ModalActions.closeModal());
      setInstanceFlag(false);
    }

    if (!UpdateCategoryModal) {
      setInstanceFlag(false);
    }

      return (
      <div>
        <IconButton onClick={handleOpen} color="primary" component="label" size="small">
          {icon}
        </IconButton>

        <Modal
            aria-labelledby="simple-modal-title"
            aria-describedby="simple-modal-description"
            open={instanceFlag && isOpen}
            onClose={handleClose}
        >
          <StyledModalBox>
            {children}
          </StyledModalBox>
        </Modal>
      </div>
      );
    }
    
    export default UpdateCategoryModal;