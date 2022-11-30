import React, { useState } from 'react';
import { IProductCategory } from '../../models/IProductCategory';
import CategoriesList from '../categories/CategoryList';

function Catalog() {
  return (
    <CategoriesList/>
  );
}

export default Catalog;