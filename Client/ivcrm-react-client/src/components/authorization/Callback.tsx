import React, { useState } from 'react';
import { Navigate } from "react-router-dom";
import AuthService from "../../services/AuthService";
import { useAuthState } from './AuthProvider';

const Callback = () => {
AuthService.signInCallback().then(() => {
    window.history.replaceState({}, window.document.title, window.location.origin + window.location.pathname);
    (window as Window).location = "http://localhost:3000/";
});
    return (
        <div>
            <Navigate to="/" replace={true} />
        </div>
    );
}

export default Callback;