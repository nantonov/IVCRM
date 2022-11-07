import Customer from "../components/pages/Customer";
import Order from "../components/pages/Order";

export interface routerType {
    title: string;
    path: string;
    element: JSX.Element;
  }

export const privateRoutes: routerType[] = [
    { title: "Customer", path: '/customers', element: <Customer />},
    { title: "Order", path: '/orders',  element: <Order />},
]
