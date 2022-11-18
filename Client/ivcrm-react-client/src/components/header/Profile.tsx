import React, { useContext } from 'react';
import { AuthContext } from '../authorization/AuthProvider';
import { Button } from '@mui/material';
import AuthService from '../../services/AuthService';

function Profile() {
    const context = useContext(AuthContext);

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