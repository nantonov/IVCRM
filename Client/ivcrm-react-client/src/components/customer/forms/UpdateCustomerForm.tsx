import React, { useState } from "react";
import Button from "@mui/material/Button";
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import FormControl from '@mui/material/FormControl';
import { ICustomer } from "../../../models/ICustomer";
import { IChangeCustomer } from "../../../models/IChangeCustomer";

interface Props {
  customer: ICustomer
  updateAction: (x: IChangeCustomer) => void
  handleClose: () => void
}


const UpdateCustomerForm: React.FC<Props> = ({customer, updateAction, handleClose}) => {

  const names = customer.fullName.split(" ");
  const [changeCustomer, setChangeCustomer] = useState<IChangeCustomer>({id: customer.id, firstName: names[0], lastName: names[1], phoneNumber: customer.phoneNumber})

    const handleSubmit = (e: React.MouseEvent<HTMLElement>) => {
        e.preventDefault()
    
        updateAction(changeCustomer);
        setChangeCustomer({id: 0, firstName: '', lastName: '', phoneNumber: ''});
        handleClose();
      }

      return (
        <FormControl>
            <Typography variant="h6" fontWeight={700}>Update customer with ID={changeCustomer.id}</Typography>
            <TextField 
              value={changeCustomer.firstName} 
              onChange={e => setChangeCustomer({...changeCustomer, firstName: e.target.value})} 
              label="First Name" 
              variant="outlined" 
              margin="dense"
              autoComplete='off'
              />
            <TextField 
              value={changeCustomer.lastName} 
              onChange={e => setChangeCustomer({...changeCustomer, lastName: e.target.value})} 
              label="Last Name" 
              variant="outlined" 
              margin="dense"
              autoComplete='off'
            />
            <TextField 
              value={changeCustomer.phoneNumber} 
              onChange={e => setChangeCustomer({...changeCustomer, phoneNumber: e.target.value})} 
              label="Phone Number" 
              variant="outlined" 
              margin="dense"
              autoComplete='off'
              />

            <Button variant="contained" onClick={handleSubmit}>Save</Button>
        </FormControl>
      );
    }
    
    export default UpdateCustomerForm;