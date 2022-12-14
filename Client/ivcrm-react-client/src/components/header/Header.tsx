import React, { useEffect, useState } from 'react';
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import IconButton from "@mui/material/IconButton";
import MenuIcon from "@mui/icons-material/Menu";
import Profile from './Profile';
import UnprocessedOrdersBadge from '../orders/UnprocessedOrdersBadge';

const Header = () => {

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
          <UnprocessedOrdersBadge/>
          <Profile/>
        </Toolbar>
      </AppBar>
    );
}
export default Header;