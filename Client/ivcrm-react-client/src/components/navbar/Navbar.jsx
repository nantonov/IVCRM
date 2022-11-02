import React from "react";
import styles from './Navbar.module.css';
import AppBar from '@mui/material/AppBar';
import CssBaseline from '@mui/material/CssBaseline';
import Typography from '@mui/material/Typography';
import Toolbar from '@mui/material/Toolbar';
import { Link } from "react-router-dom";

const Navbar = () => {
  return (
    <AppBar position="static">
      <CssBaseline />
      <Toolbar>
        <Typography variant="h4" >
          Navbar
        </Typography>
        {/*
          <div>
            <Link to="/">
              Home
            </Link>
            <Link to="/about">
              About
            </Link>
            <Link to="/contact">
              Contact
            </Link>
            <Link to="/faq">
              FAQ
            </Link>
          </div>
  */}
      </Toolbar>
    </AppBar>
  );
}

export default Navbar;