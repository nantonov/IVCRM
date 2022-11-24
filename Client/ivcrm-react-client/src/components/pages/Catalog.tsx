import React, { useEffect, useState } from 'react';
import ProductCategoryService from "../../services/ProductCategoryService";
import { IProductCategory } from '../../models/IProductCategory';
import CategoriesList from '../categories/CategoriesList';
import { IChangeProductCategory } from '../../models/IChangeProductCategory';

function Catalog() {
  const [categories, setCategories] = useState<Array<IProductCategory>>([])

  useEffect(() => {
    fetchProductCategories()
  }, [])

  async function fetchProductCategories() {
    const categories = await ProductCategoryService.getAll();
    setCategories(categories)
  }

  async function createCategory(category: IChangeProductCategory) {
    const createdCategory = await ProductCategoryService.create(category);
    !createdCategory.parentCategoryId ? setCategories([...categories, createdCategory]) : fetchProductCategories()
  }

  async function updateCategory(customer: IChangeProductCategory) {
    const updatedCategory = await ProductCategoryService.update(customer);
    !updatedCategory.parentCategoryId ? setCategories({...categories, [updatedCategory.id]: updatedCategory}) : fetchProductCategories()
  }

  async function deleteCategory(id: number) {
    await ProductCategoryService.delete(id);
    setCategories(categories.filter(x => x.id !== id))
  }

  return (
        <CategoriesList categories={categories} createAction={createCategory} updateAction={updateCategory} deleteAction={deleteCategory}/>
  );
}

export default Catalog;