import { TreeItem, TreeView } from "@mui/lab";
import { IProductCategory } from "../../models/IProductCategory";

import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import ChevronRightIcon from '@mui/icons-material/ChevronRight';

interface Props {
    categories: Array<IProductCategory>
  }

  const getTreeItemsFromData = (treeItems: Array<IProductCategory>) => {
    return treeItems.map(treeItemData => {
      let children = undefined;
      if (treeItemData.childCategories && treeItemData.childCategories.length > 0) {
        children = getTreeItemsFromData(treeItemData.childCategories);
      }
      return (
        <TreeItem
          key={treeItemData.id}
          nodeId={treeItemData.id.toString()}
          label={treeItemData.name}
          children={children}
        />
      );
    });
  };

  const CategoriesTree: React.FC<Props> = ({categories}) => {

    return (
        <TreeView
        defaultCollapseIcon={<ExpandMoreIcon />}
        defaultExpandIcon={<ChevronRightIcon />}
      >
        {getTreeItemsFromData(categories)}
      </TreeView>

  );
}

export default CategoriesTree;