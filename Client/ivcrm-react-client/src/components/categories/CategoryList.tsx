import * as React from 'react';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemText from '@mui/material/ListItemText';
import { IProductCategory } from '../../models/IProductCategory';
import { Grid, Divider } from '@mui/material';
import SubCategoriesList from './SubCategoryList';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { fetchCategoriesTree } from '../../store/reducers/categories/ActionCreators';
import { useEffect } from 'react';

const CategoriesList = () => {

    const [subCategories, setSubCategories] = React.useState<Array<IProductCategory>>([])

    const {categoriesTree} = useAppSelector(state => state.categoryReducer)
    const dispatch = useAppDispatch()
  
    useEffect(() => {
      dispatch(fetchCategoriesTree())
    }, [])

    const handleMouseEnter = (category: IProductCategory) => {
      setSubCategories(category.childCategories)
     }
  
    const getListItemsFromData = (items: Array<IProductCategory>) => {
      return items.map(treeItemData => {
        return (
          <ListItem disablePadding key={treeItemData.id}>
            <ListItemButton onMouseEnter={() => handleMouseEnter(treeItemData)}>
              {<ListItemText primary={treeItemData.name} />}
              {/*treeItemData.name*/}
            </ListItemButton>
          </ListItem>
        );
      });
    };

    return (
      <Grid direction='row' container spacing={1}>
        <Grid container item sm={3}>
          <List>
            {getListItemsFromData(categoriesTree)}
          </List>
        </Grid>
        <Divider orientation="vertical" flexItem/>
        <Grid container item sm={8}>
          <SubCategoriesList categories={subCategories}/>
        </Grid>
      </Grid>

  );
}

export default CategoriesList;