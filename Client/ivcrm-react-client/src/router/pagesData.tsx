import Callback from "../components/authorization/Callback";
import Logout from "../components/authorization/Logout";
import Refresh from "../components/authorization/Refresh";
import Catalog from "../components/pages/Catalog";
import Categories from "../components/pages/Categories";
import Customer from "../components/pages/Customer";
import Home from "../components/pages/Home";
import Order from "../components/pages/Order";
import Products from "../components/pages/Products";

export interface routerType {
    title: string;
    path: string;
    element: JSX.Element;
  }

export const privateRoutes: routerType[] = [
    { title: "Catalog", path: '/catalog', element: <Catalog />},
    { title: "Products", path: '/products', element: <Products />},
    { title: "Categories", path: '/categories', element: <Categories />},
    { title: "Customer", path: '/customers', element: <Customer />},
    { title: "Order", path: '/orders',  element: <Order />},
    { title: "Callback", path: '/callback',  element: <Callback />},
    { title: "Logout", path: '/logout',  element: <Logout />},
    { title: "Refresh", path: '/refresh',  element: <Refresh />},
    { title: "Home", path: '/',  element: <Home />},
]
