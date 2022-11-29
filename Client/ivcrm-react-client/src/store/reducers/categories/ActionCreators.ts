import ProductCategoryService from "../../../services/ProductCategoryService";
import { createAsyncThunk } from "@reduxjs/toolkit";
import { IChangeProductCategory } from "../../../models/IChangeProductCategory";

export const fetchCategories = createAsyncThunk(
    'category/getAll',
    async (_, thunkAPI) => { 
        try {
            const response = await ProductCategoryService.getAll()
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)

export const createCategory = createAsyncThunk(
    'category/create',
    async (customer :IChangeProductCategory, thunkAPI) => { 
        try {
            const response = await ProductCategoryService.create(customer)
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)

export const updateCategory = createAsyncThunk(
    'category/update',
    async (category :IChangeProductCategory, thunkAPI) => { 
        try {
            const response = await ProductCategoryService.update(category)
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)

export const deleteCategory = createAsyncThunk(
    'category/delete',
    async (id :number, thunkAPI) => { 
        try {
            const response = await ProductCategoryService.delete(id)
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)
