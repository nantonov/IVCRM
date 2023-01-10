import ProductService from "../../../services/ProductService";
import { createAsyncThunk } from "@reduxjs/toolkit";
import { IChangeProduct } from "../../../models/IChangeProduct";
import { IPictureModel } from "../../../models/IPictureModel";

export const fetchProducts = createAsyncThunk(
    'product/getAll',
    async (_, thunkAPI) => { 
        try {
            const response = await ProductService.getAll()
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)

export const getProductById = createAsyncThunk(
    'product/getById',
    async (id: number, thunkAPI) => { 
        try {
            const response = await ProductService.getById(id)
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)

export const createProduct = createAsyncThunk(
    'product/create',
    async (customer :IChangeProduct, thunkAPI) => { 
        try {
            const response = await ProductService.create(customer)
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)

export const updateProduct = createAsyncThunk(
    'product/update',
    async (category :IChangeProduct, thunkAPI) => { 
        try {
            const response = await ProductService.update(category)
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)

export const deleteProduct = createAsyncThunk(
    'product/delete',
    async (id :number, thunkAPI) => { 
        try {
            const response = await ProductService.delete(id)
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)

export const uploadPicture = createAsyncThunk(
    'product/picture',
    async (picture :IPictureModel, thunkAPI) => { 
        try {
            const response = await ProductService.uploadPicture(picture)
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)
