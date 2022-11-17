import * as React from 'react';
import {
  Nav,
  NavLink,
  Bars,
} from './NavbarElements';

const Navbar = () => {

  return (
    <Nav>
    <Bars />
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
        <NavLink 
          to="/profile" 
        >
            Profile
        </NavLink>
        </Nav>
  );
}
export default Navbar;