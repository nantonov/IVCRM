import React from 'react';
import { Navigate } from "react-router-dom";
import authService from "../../services/AuthService";

const Refresh : React.FC = () => {
    authService.signInSilentCallback();
    return (
        <div>
            <Navigate to="/" replace={true} />
        </div>
    );
}

export default Refresh;