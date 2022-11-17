import React from 'react';
import { Navigate } from "react-router-dom";
import authService from "../../services/AuthService";

const Logout : React.FC = () => {
    authService.signOutCallback();
    console.log('SignOut');
    return (
        <div>
            <Navigate to="/" replace={true} />
        </div>
    );
}

export default Logout;