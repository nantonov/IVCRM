import Callback from "../components/authorization/Callback";
import Logout from "../components/authorization/Logout";
import Refresh from "../components/authorization/Refresh";
import CatalogPage from "../components/pages/CatalogPage";
import CategoriesPage from "../components/pages/CategoriesPage";
import CustomersPage from "../components/pages/CustomersPage";
import HomePage from "../components/pages/HomePage";
import OrderDetailsPage from "../components/pages/OrderDetailsPage";
import OrdersPage from "../components/pages/OrdersPage";
import ProductDetailsPage from "../components/pages/ProductDetailsPage";
import ProductsPage from "../components/pages/ProductsPage";

export interface routerType {
    title: string;
    path: string;
    element: JSX.Element;
  }

export const privateRoutes: routerType[] = [
    { title: "Catalog", path: '/catalog', element: <CatalogPage />},
    { title: "Products", path: '/products', element: <ProductsPage />},
    { title: "ProductDetails", path: '/products/:productId',  element: <ProductDetailsPage />},
    { title: "Categories", path: '/categories', element: <CategoriesPage />},
    { title: "Customer", path: '/customers', element: <CustomersPage />},
    { title: "Order", path: '/orders',  element: <OrdersPage />},
    { title: "OrderDetails", path: '/orders/:orderId',  element: <OrderDetailsPage />},
    { title: "Callback", path: '/callback',  element: <Callback />},
    { title: "Logout", path: '/logout',  element: <Logout />},
    { title: "Refresh", path: '/refresh',  element: <Refresh />},
    { title: "Home", path: '/',  element: <HomePage />},
]
