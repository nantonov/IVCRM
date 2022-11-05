import * as React from 'react';
import {Link, NavLink} from "react-router-dom";

const Navigation = () => {

  return (
    <nav>
        <NavLink 
          to="/"
        >
            Home
        </NavLink>
        <NavLink 
          to="/customers"
        >
            Customers
        </NavLink>
        <NavLink 
          to="/orders" 
        >
            Orders
        </NavLink>
   </nav> 
  );
}
export default Navigation;