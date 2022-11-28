import React, { useContext, useEffect } from 'react';
import { Button } from '@mui/material';
import AuthService from '../../services/AuthService';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { getUser } from '../../store/reducers/auth/ActionCreators';

function Profile() {
    /*const context = useContext(AuthContext);

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
        );*/

        const {user, isAuth, isLoading, error} = useAppSelector(state => state.authReducer)
        const dispatch = useAppDispatch()
      
        useEffect(() => {
          dispatch(getUser())
        }, [])

    if (!isAuth) {
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