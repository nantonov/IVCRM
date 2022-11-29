import React, { useContext, useEffect } from 'react';
import { Button } from '@mui/material';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { getUser, signIn, signOut } from '../../store/reducers/auth/ActionCreators';

function Profile() {
        const {user, isAuth} = useAppSelector(state => state.authReducer)
        const dispatch = useAppDispatch()
      
        useEffect(() => {
          dispatch(getUser())
        }, [])

    if (!isAuth) {
        return (
        <>
        <Button onClick={() => dispatch(signIn())} color="inherit">Login</Button>
      </>
      );
      }
      return (
        <>
          <Button onClick={() => dispatch(signOut())} color="inherit">Logout</Button>
        </>
        );
}

export default Profile;