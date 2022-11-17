import React, { useContext } from 'react';
import Typography from '@mui/material/Typography';
import { AuthContext } from '../authorization/AuthProvider';
import { Navigate } from 'react-router-dom';
import { Button } from '@mui/material';
import AuthService from '../../services/AuthService';

function Profile() {
    const context = useContext(AuthContext);
    //is it nessesary???
    const handleSubmit = (e: React.MouseEvent<HTMLElement>) => {
      e.preventDefault()}

    if (!context.isAuth) {
        return (
        <>
        <Button onClick={async () => await AuthService.signIn()} color="inherit">Login</Button>
      </>
      );
      }
      return (
        <>
          <Button onClick={async () => await AuthService.signOut()} color="inherit">Logout</Button>
        </>
        );
}

export default Profile;