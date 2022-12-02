import { IProductCategory } from "../../models/IProductCategory";

import { Button, List, ListItem, ListItemButton, ListItemText } from "@mui/material";
import { NavLink } from "react-router-dom";

interface Props {
    categories: Array<IProductCategory>
  }

  const ChildCategoriesList: React.FC<Props> = ({categories}) => {

    const getListItems = (items: Array<IProductCategory>) => {
        return items.map(treeItemData => {
          return (
            <div key={treeItemData.id}>
            <ListItem disablePadding>

                <ListItemButton>
                  <ListItemText primary={treeItemData.name} />
              </ListItemButton>
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
               <NavLink to="/products" style={{ textDecoration: "none" }}>
                <ListItemButton>
                  <ListItemText primary={' - ' + treeItemData.name} />
              </ListItemButton>
              </NavLink>
            </ListItem>
          );
        });
      };

    return (
      <List>
        {getListItems(categories)}
      </List>
                

  );
}

export default ChildCategoriesList;