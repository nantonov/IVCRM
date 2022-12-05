import React, { useEffect, useState } from 'react';
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import IconButton from "@mui/material/IconButton";
import MenuIcon from "@mui/icons-material/Menu";
import Profile from './Profile';

import * as signalR from "@microsoft/signalr";

const Header = () => {

  const[countAlert, setCountAlert] = useState(2)

  useEffect(() => {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7021/notificationHub')
      .withAutomaticReconnect()
      .build();
  
    connection.start()
    .then(result => {
        console.log('Connected!');
  
        connection.on('ReceiveNotification', message => {
          console.log(message);
           setCountAlert(countAlert+1)
           console.log(countAlert);
          
        });
    })
    .catch(e => console.log('Connection failed: ', e));
  }, []);

    return (
        <AppBar position="static">
        <Toolbar>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 2 }}
          >
            <MenuIcon />
          </IconButton>
          <Typography variant="h6" 
            component="div" sx={{ flexGrow: 1 }}>
              IVCRM
          </Typography>
          <Typography variant="h6" 
            component="div" sx={{ flexGrow: 1 }}>
              {countAlert}
          </Typography>
          <Profile/>
        </Toolbar>
      </AppBar>
    );
}
export default Header;