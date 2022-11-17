import Callback from "../components/authorization/Callback";
import Logout from "../components/authorization/Logout";
import Refresh from "../components/authorization/Refresh";
import Customer from "../components/pages/Customer";
import Home from "../components/pages/Home";
import Order from "../components/pages/Order";
import Profile from "../components/header/Profile";

export interface routerType {
    title: string;
    path: string;
    element: JSX.Element;
  }

export const privateRoutes: routerType[] = [
    { title: "Customer", path: '/customers', element: <Customer />},
    { title: "Order", path: '/orders',  element: <Order />},
    { title: "Profile", path: '/profile',  element: <Profile />},
    { title: "Callback", path: '/callback',  element: <Callback />},
    { title: "Logout", path: '/logout',  element: <Logout />},
    { title: "Refresh", path: '/refresh',  element: <Refresh />},
    { title: "Home", path: '/',  element: <Home />},
]
