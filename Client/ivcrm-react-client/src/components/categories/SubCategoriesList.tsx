import { IProductCategory } from "../../models/IProductCategory";

import { Button, List, ListItem, ListItemButton, ListItemText } from "@mui/material";
import { IChangeProductCategory } from "../../models/IChangeProductCategory";
import CreateCategoryModal from "./modals/CreateCategoryModal";
import UpdateCategoryModal from "./modals/UpdateCategoryModal";
import DeleteCategoryModal from "./modals/DeleteCategoryModal";

interface Props {
    parentCategoryId: number
    categories: Array<IProductCategory>
    createAction: (x: IChangeProductCategory) => void
    updateAction: (x: IChangeProductCategory) => void
    deleteAction: (x: number) => void
  }

  const SubCategoriesList: React.FC<Props> = ({parentCategoryId, categories, createAction, updateAction, deleteAction}) => {

    const getListItems = (items: Array<IProductCategory>) => {
        return items.map(treeItemData => {
          return (
            <div key={treeItemData.id}>
            <ListItem disablePadding>
                <ListItemButton>
                  <ListItemText primary={treeItemData.name} />
              </ListItemButton>
              <CreateCategoryModal parentCategory={treeItemData.id} createAction={createAction}/>
                <UpdateCategoryModal category={treeItemData} updateAction={updateAction}/>
                <DeleteCategoryModal categoryId={treeItemData.id} deleteAction={deleteAction}/>
            </ListItem>
            {getChildListItems(treeItemData.childCategories)}
            
            </div>
          );
        });
      };
    
      const getChildListItems = (items: Array<IProductCategory>) => {
        return items.map(treeItemData => {
          return (
            <ListItem disablePadding key={treeItemData.id}>
                <ListItemButton>
                  <ListItemText primary={' - ' + treeItemData.name} />
              </ListItemButton>
                <UpdateCategoryModal category={treeItemData} updateAction={updateAction}/>
                <DeleteCategoryModal categoryId={treeItemData.id} deleteAction={deleteAction}/>
            </ListItem>
          );
        });
      };

    return (
        <List>
        {getListItems(categories)}
        <CreateCategoryModal parentCategory={parentCategoryId} createAction={createAction}/>
        </List>
                

  );
}

export default SubCategoriesList;