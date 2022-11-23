import React, { useEffect, useState } from 'react';
import ProductCategoryService from "../../services/ProductCategoryService";
import { IProductCategory } from '../../models/IProductCategory';
import CategoriesTree from '../categories/CategoriesTree';
import { Grid } from '@mui/material';

function Catalog() {
  const [categories, setCategories] = useState<Array<IProductCategory>>([])

  useEffect(() => {
    fetchProductCategories()
  }, [])

  async function fetchProductCategories() {
    const categories = await ProductCategoryService.getAll();
    setCategories(categories)
  }

  return (
    <Grid direction='row' container spacing={1}>
      <Grid container item sm={3}>
        <CategoriesTree categories={categories}/>
      </Grid>
      <Grid container item sm={9}>
        Some catalog...
      </Grid>
    </Grid>
  );
}

export default Catalog;