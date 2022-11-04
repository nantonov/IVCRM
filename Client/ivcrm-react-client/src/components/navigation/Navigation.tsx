import * as React from 'react';
import {Link} from "react-router-dom";

const Navigation = () => {

  return (
    <nav>
      <Link to='/customers'>cust</Link>
      <Link to='/orders'>ord</Link>
    </nav>
  );
}
export default Navigation;
