import { ICustomer } from "../../../models/ICustomer";
import { createSlice, PayloadAction } from "@reduxjs/toolkit"
import { createCustomer, deleteCustomer, fetchCustomers, updateCustomer } from "./ActionCreators";

interface ICustomerState {
    customers: ICustomer[];
    customer: ICustomer;
    isLoading: boolean;
    error: string;
}

const initialState: ICustomerState = {
    customers: [],
    customer: {} as ICustomer,
    isLoading: false,
    error: '',
}

export const customerSlice = createSlice({
    name: 'customer',
    initialState,
    reducers: {},
    extraReducers: {
        [fetchCustomers.fulfilled.type]: (state, action: PayloadAction<Array<ICustomer>>) => {
            state.isLoading = false;
            state.error = '';
            state.customers = action.payload;
        },
        [fetchCustomers.pending.type]: (state) => {
            state.isLoading = true;
        },
        [fetchCustomers.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [createCustomer.fulfilled.type]: (state, action: PayloadAction<ICustomer>) => {
            state.isLoading = false;
            state.error = '';
            state.customers = [...state.customers,  action.payload];
        },
        [createCustomer.pending.type]: (state) => {
            state.isLoading = true;
        },
        [createCustomer.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [updateCustomer.fulfilled.type]: (state, action: PayloadAction<ICustomer>) => {
            state.isLoading = false;
            state.error = '';
            state.customers = state.customers.map((item) => item.id === action.payload.id ? action.payload : item);
        },
        [updateCustomer.pending.type]: (state) => {
            state.isLoading = true;
        },
        [updateCustomer.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [deleteCustomer.fulfilled.type]: (state, action: any) => {
            state.isLoading = false;
            state.error = '';
            state.customers = state.customers.filter(x => x.id !== action.meta.arg);
        },
        [deleteCustomer.pending.type]: (state) => {
            state.isLoading = true;
        },
        [deleteCustomer.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
    }
})

export default customerSlice.reducer;
