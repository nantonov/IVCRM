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

interface Props {
    categories: Array<IProductCategory>
    createAction: (x: IChangeProductCategory) => void
    updateAction: (x: IChangeProductCategory) => void
    deleteAction: (x: number) => void
  }

const CategoriesList: React.FC<Props> = ({categories, createAction, updateAction, deleteAction}) => {

    const [subCategories, setSubCategories] = React.useState<Array<IProductCategory>>([])
    const [actualCategoryId, setactualCategoryId] = React.useState<number>()

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
                <UpdateCategoryModal category={treeItemData} updateAction={updateAction}/>
                <DeleteCategoryModal categoryId={treeItemData.id} deleteAction={deleteAction}/>
          </ListItem>
        );
      });
    };

    return (
      <Grid direction='row' container spacing={1}>
        <Grid container item sm={3}>
          <List>
            {getListItemsFromData(categories)}
            <CreateCategoryModal createAction={createAction}/>
          </List>
        </Grid>
        <Divider orientation="vertical" flexItem/>
        <Grid container item sm={8}>
          <SubCategoriesList parentCategoryId={actualCategoryId!} categories={subCategories} createAction={createAction} updateAction={updateAction} deleteAction={deleteAction}/>
        </Grid>
      </Grid>

  );
}

export default CategoriesList;