
import React, { useState } from "react";
import Modal from "@mui/material/Modal";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import TextField from '@mui/material/TextField';
import FormControl from '@mui/material/FormControl';

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

const CreateCustomer = ({create}) => {
    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

    const [customer, setCustomer] = useState({firstName: '', lastName: '', phoneNumber: ''})

    const handleSubmit = (e) => {
        e.preventDefault()
    
        create(customer);
        setCustomer({firstName: '', lastName: '', phoneNumber: ''});
        handleClose();
      }

      return (
        <div>
        <Button onClick={handleOpen}>Save</Button>

        <Modal
            aria-labelledby="simple-modal-title"
            aria-describedby="simple-modal-description"
            open={open}
            onClose={handleClose}
        >
        <Box sx={style}>
        <FormControl>
            <TextField value={customer.firstName} onChange={e => setCustomer({...customer, firstName: e.target.value})}  label="Outlined" variant="outlined" />
            <TextField value={customer.lastName} onChange={e => setCustomer({...customer, lastName: e.target.value})}  label="Outlined" variant="outlined" />
            <TextField value={customer.phoneNumber} onChange={e => setCustomer({...customer, phoneNumber: e.target.value})}  label="Outlined" variant="outlined" />
            <Button variant="contained" onClick={handleSubmit}>Contained</Button>
        </FormControl>
        </Box>
      </Modal>
      </div>
      );
    }
    
    export default CreateCustomer;