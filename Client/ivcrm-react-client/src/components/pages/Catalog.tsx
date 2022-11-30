import { Divider, Grid } from '@mui/material';
import React, { useState } from 'react';
import { IProductCategory } from '../../models/IProductCategory';
import CategoriesList from '../categories/CategoryList';
import ProductList from '../products/ProductList';

function Catalog() {
  return (

      <Grid direction='row' container spacing={1}>
        <Grid container item sm={5}>
        <CategoriesList/>
      
        </Grid>
        <Divider orientation="vertical" flexItem/>
        <Grid container item sm={5}>
          <ProductList/>
        </Grid>
      </Grid>
  );
}

export default Catalog;