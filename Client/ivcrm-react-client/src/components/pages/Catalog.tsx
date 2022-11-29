import React, { useState } from 'react';
import { IProductCategory } from '../../models/IProductCategory';
import CategoriesList from '../categories/CategoriesList';

function Catalog() {
  return (
    <CategoriesList/>
  );
}

export default Catalog;