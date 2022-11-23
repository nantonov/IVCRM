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
        <NavLink to="/">Home</NavLink>
        <NavLink to="/catalog">Catalog</NavLink>
        <NavLink to="/customers">Customers</NavLink>
        <NavLink to="/orders">Orders</NavLink>
    </Nav>
  );
}
export default Navbar;