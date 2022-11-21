import { createContext, useContext, useState, useEffect } from 'react'
import AuthService from "../../services/AuthService";

type User = Awaited<ReturnType<typeof AuthService.getUser>>;

interface AuthProviderProps {
    children: React.ReactNode;
}

type AuthProps = ReturnType<typeof useAuthState>;

 export const useAuthState = () => {
    const [user, setUser] = useState<User>(null);
    const [isAuth, setIsAuth] = useState(false);

    useEffect(() => {
        AuthService.getUser().then(user => {
            setUser(user);
            setIsAuth(user !== null);
        });
    }, []);

    return { user, isAuth };
};

export const AuthContext = createContext<AuthProps>({
    user: null,
    isAuth: false
});

const useAuthContext = () => useContext(AuthContext)

const AuthProvider: React.FC<AuthProviderProps>= ({ children }) => {

    const auth = useAuthState()

    return <AuthContext.Provider value={auth}>
        {children}
    </AuthContext.Provider>
}

export { useAuthContext, AuthProvider }