import React, { useContext } from 'react';
import Typography from '@mui/material/Typography';
import { AuthContext } from '../authorization/AuthProvider';
import { Navigate } from 'react-router-dom';
import { Button } from '@mui/material';
import AuthService from '../../services/AuthService';

function Home() {
      return (
        <>
          <h1>Home</h1>
        </>
        );
}

export default Home;