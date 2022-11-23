import React, { useEffect, useState } from 'react';
import ProductCategoryService from "../../services/ProductCategoryService";
import TreeView from '@mui/lab/TreeView';
import { IProductCategory } from '../../models/IProductCategory';
import TreeItem from '@mui/lab/TreeItem/TreeItem';

import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import ChevronRightIcon from '@mui/icons-material/ChevronRight';

function Catalog() {
  const [categories, setCategories] = useState<Array<IProductCategory>>([])

  useEffect(() => {
    fetchProductCategories()
  }, [])

  async function fetchProductCategories() {
    const categories = await ProductCategoryService.getAll();
    setCategories(categories)
  }

  const renderTree = (tree: IProductCategory) => {
    return <TreeItem key={tree.id} nodeId={tree.id.toString()} label={tree.id}>
            {tree.childCategories && tree.childCategories.map(renderTree)}
         </TreeItem>
  } 

  return (
<TreeView
  aria-label="file system navigator"
  defaultCollapseIcon={<ExpandMoreIcon />}
  defaultExpandIcon={<ChevronRightIcon />}
  sx={{ height: 240, flexGrow: 1, maxWidth: 400, overflowY: 'auto' }}
>
    {renderTree(categories[0])}
    </TreeView>
  );
}

export default Catalog;