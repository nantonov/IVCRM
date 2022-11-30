import * as React from 'react';
import List from '@mui/material/List';
import { Grid, Divider } from '@mui/material';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { useEffect } from 'react';
import { fetchProducts } from '../../store/reducers/products/ActionCreators';
import ProductCard from './ProductCard';
import { IProduct } from '../../models/IProduct';

const ProductList = () => {
    const {products, isLoading, error} = useAppSelector(state => state.productReducer)
  const dispatch = useAppDispatch()

    useEffect(() => {
      dispatch(fetchProducts());
    }, [])
  
    const getListItemsFromData = (items: Array<IProduct>) => {
      return items.map(item => {
        return (
          <ProductCard product={item}/>
        );
      });
    };

    return (
      <Grid direction='row' container spacing={1}>
        <Grid container item sm={3}>
          <List>
            {getListItemsFromData(products)}
          </List>
        </Grid>
        <Divider orientation="vertical" flexItem/>
        <Grid container item sm={8}>
        </Grid>
      </Grid>

  );
}

export default ProductList;