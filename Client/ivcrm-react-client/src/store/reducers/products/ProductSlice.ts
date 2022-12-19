import { createSlice, PayloadAction } from "@reduxjs/toolkit"
import { createProduct, deleteProduct, fetchProducts, updateProduct } from "./ActionCreators";
import { IProduct } from "../../../models/IProduct";

interface IProductState {
    products: IProduct[];
    isLoading: boolean;
    error: string;
}

const initialState: IProductState = {
    products: [],
    isLoading: false,
    error: '',
}

export const productSlice = createSlice({
    name: 'product',
    initialState,
    reducers: {},
    extraReducers: {
        [fetchProducts.fulfilled.type]: (state, action: PayloadAction<Array<IProduct>>) => {
            state.isLoading = false;
            state.error = '';
            state.products = action.payload;
        },
        [fetchProducts.pending.type]: (state) => {
            state.isLoading = true;
        },
        [fetchProducts.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [createProduct.fulfilled.type]: (state, action: PayloadAction<IProduct>) => {
            state.isLoading = false;
            state.error = '';
            state.products = [...state.products,  action.payload];
        },
        [createProduct.pending.type]: (state) => {
            state.isLoading = true;
        },
        [createProduct.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [updateProduct.fulfilled.type]: (state, action: PayloadAction<IProduct>) => {
            state.isLoading = false;
            state.error = '';
            state.products = state.products.map((item) => item.id === action.payload.id ? action.payload : item);;
        },
        [updateProduct.pending.type]: (state) => {
            state.isLoading = true;
        },
        [updateProduct.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [deleteProduct.fulfilled.type]: (state, action: any) => {
            state.isLoading = false;
            state.error = '';
            state.products = state.products.filter(x => x.id !== action.meta.arg);
        },
        [deleteProduct.pending.type]: (state) => {
            state.isLoading = true;
        },
        [deleteProduct.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
    }
})

export default productSlice.reducer;
