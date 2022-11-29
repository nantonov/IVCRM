import { IProductCategory } from "../../models/IProductCategory";

import { Button, List, ListItem, ListItemButton, ListItemText } from "@mui/material";
import CreateCategoryModal from "./modals/CreateCategoryModal";
import UpdateCategoryModal from "./modals/UpdateCategoryModal";
import DeleteCategoryModal from "./modals/DeleteCategoryModal";

interface Props {
    parentCategoryId: number
    categories: Array<IProductCategory>
  }

  const SubCategoriesList: React.FC<Props> = ({parentCategoryId, categories}) => {

    const getListItems = (items: Array<IProductCategory>) => {
        return items.map(treeItemData => {
          return (
            <div key={treeItemData.id}>
            <ListItem disablePadding>
                <ListItemButton>
                  <ListItemText primary={treeItemData.name} />
              </ListItemButton>
              <CreateCategoryModal parentCategoryId={treeItemData.id}/>
                <UpdateCategoryModal category={treeItemData}/>
                <DeleteCategoryModal categoryId={treeItemData.id}/>
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
                <UpdateCategoryModal category={treeItemData}/>
                <DeleteCategoryModal categoryId={treeItemData.id}/>
            </ListItem>
          );
        });
      };

    return (
      <List>
        {getListItems(categories)}
        <CreateCategoryModal parentCategoryId={parentCategoryId}/>
      </List>
                

  );
}

export default SubCategoriesList;