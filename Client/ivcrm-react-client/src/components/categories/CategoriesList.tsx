import * as React from 'react';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemText from '@mui/material/ListItemText';
import { IProductCategory } from '../../models/IProductCategory';
import { Grid, Divider } from '@mui/material';
import SubCategoriesList from './SubCategoriesList';
import { IChangeProductCategory } from '../../models/IChangeProductCategory';
import UpdateCategoryModal from './modals/UpdateCategoryModal';
import DeleteCategoryModal from './modals/DeleteCategoryModal';
import CreateCategoryModal from './modals/CreateCategoryModal';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { fetchCategories } from '../../store/reducers/categories/ActionCreators';
import { useEffect } from 'react';

const CategoriesList = () => {

    const [subCategories, setSubCategories] = React.useState<Array<IProductCategory>>([])
    const [actualCategoryId, setactualCategoryId] = React.useState<number>()

    const {categories, isLoading, error} = useAppSelector(state => state.categoryReducer)
    const dispatch = useAppDispatch()
  
    useEffect(() => {
      dispatch(fetchCategories())
    }, [])

    const handleMouseEnter = (category: IProductCategory) => {
      setSubCategories(category.childCategories)
      setactualCategoryId(category.id)
     }
  
    const getListItemsFromData = (items: Array<IProductCategory>) => {
      return items.map(treeItemData => {
        return (
          <ListItem disablePadding key={treeItemData.id}>
            <ListItemButton onMouseEnter={() => handleMouseEnter(treeItemData)}>
              <ListItemText primary={treeItemData.name} />
            </ListItemButton>
                <UpdateCategoryModal category={treeItemData}/>
                <DeleteCategoryModal categoryId={treeItemData.id}/>
          </ListItem>
        );
      });
    };

    return (
      <Grid direction='row' container spacing={1}>
        <Grid container item sm={3}>
          <List>
            {getListItemsFromData(categories)}
            <CreateCategoryModal/>
          </List>
        </Grid>
        <Divider orientation="vertical" flexItem/>
        <Grid container item sm={8}>
          <SubCategoriesList parentCategoryId={actualCategoryId!} categories={subCategories}/>
        </Grid>
      </Grid>

  );
}

export default CategoriesList;