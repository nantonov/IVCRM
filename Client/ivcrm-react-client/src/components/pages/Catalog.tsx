import React, { useEffect, useState } from 'react';
import ProductCategoryService from "../../services/ProductCategoryService";
import { IProductCategory } from '../../models/IProductCategory';
import CategoriesList from '../categories/CategoriesList';
import { IChangeProductCategory } from '../../models/IChangeProductCategory';

function Catalog() {
  const [categories, setCategories] = useState<Array<IProductCategory>>([])

  return (
        <CategoriesList/>
  );
}

export default Catalog;