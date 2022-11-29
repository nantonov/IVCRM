import { createSlice, PayloadAction } from "@reduxjs/toolkit"
import { createCategory, deleteCategory, fetchCategories, updateCategory } from "./ActionCreators";
import { IProductCategory } from "../../../models/IProductCategory";

interface ICategoryState {
    categories: IProductCategory[];
    actualCategoryId: number;
    isLoading: boolean;
    error: string;
}

const initialState: ICategoryState = {
    categories: [],
    actualCategoryId: 0,
    isLoading: false,
    error: '',
}

export const categorySlice = createSlice({
    name: 'category',
    initialState,
    reducers: {},
    extraReducers: {
        [fetchCategories.fulfilled.type]: (state, action: PayloadAction<Array<IProductCategory>>) => {
            state.isLoading = false;
            state.error = '';
            state.categories = action.payload;
        },
        [fetchCategories.pending.type]: (state) => {
            state.isLoading = true;
        },
        [fetchCategories.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [createCategory.fulfilled.type]: (state, action: PayloadAction<IProductCategory>) => {
            state.isLoading = false;
            state.error = '';
            state.categories = [...state.categories,  action.payload];
        },
        [createCategory.pending.type]: (state) => {
            state.isLoading = true;
        },
        [createCategory.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [updateCategory.fulfilled.type]: (state, action: PayloadAction<IProductCategory>) => {
            state.isLoading = false;
            state.error = '';
            state.categories = state.categories.map((item) => item.id === action.payload.id ? action.payload : item);
        },
        [updateCategory.pending.type]: (state) => {
            state.isLoading = true;
        },
        [updateCategory.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [deleteCategory.fulfilled.type]: (state, action: any) => {
            state.isLoading = false;
            state.error = '';
            state.categories = state.categories.filter(x => x.id !== action.meta.arg);
        },
        [deleteCategory.pending.type]: (state) => {
            state.isLoading = true;
        },
        [deleteCategory.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
    }
})

export default categorySlice.reducer;
