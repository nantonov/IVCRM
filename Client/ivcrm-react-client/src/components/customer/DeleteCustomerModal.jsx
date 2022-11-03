
import React, { useState } from "react";
import Modal from "@mui/material/Modal";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import TextField from '@mui/material/TextField';
import FormControl from '@mui/material/FormControl';
import Delete from '@mui/icons-material/Delete';
import IconButton from '@mui/material/IconButton';

const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
  };

const CreateCustomer = ({deleteCustomer, rowId}) => {
    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

    const handleSubmit = (e) => {
        e.preventDefault()
    
        deleteCustomer(rowId);
        handleClose();
      }

      return (
        <div>
        <IconButton onClick={handleOpen} color="primary" aria-label="upload picture" component="label">
        <input hidden accept="image/*" type="file" />
        <Delete />
        </IconButton>

        <Modal
            aria-labelledby="simple-modal-title"
            aria-describedby="simple-modal-description"
            open={open}
            onClose={handleClose}
        >
        <Box sx={style}>
        <FormControl>
          <TextField value={rowId} label="Outlined" variant="outlined" inputProps={{readOnly: true,}} />
            <Button variant="contained" onClick={handleSubmit}>delete</Button>
            <Button variant="contained" onClick={handleClose}>cancel</Button>
        </FormControl>
        </Box>
      </Modal>
      </div>
      );
    }
    
    export default CreateCustomer;