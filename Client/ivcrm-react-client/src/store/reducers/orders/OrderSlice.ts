import { IOrder } from "../../../models/IOrder";
import { createSlice, PayloadAction } from "@reduxjs/toolkit"
import { createOrder, deleteOrder, fetchOrders, getOrderById, updateOrder } from "./ActionCreators";
import { IOrderDetails } from "../../../models/IOrderDetails";
import { IOrderItem } from "../../../models/IOrderItem";
import { ICustomer } from "../../../models/ICustomer";

interface IOrderState {
    orders: IOrder[];
    order: IOrderDetails;
    isLoading: boolean;
    error: string;
}

const initialState: IOrderState = {
    orders: [],
    order: {customer: {} as ICustomer, orderItems: new Array<IOrderItem>} as IOrderDetails,
    isLoading: false,
    error: '',
}

export const orderSlice = createSlice({
    name: 'order',
    initialState,
    reducers: {},
    extraReducers: {
        [fetchOrders.fulfilled.type]: (state, action: PayloadAction<Array<IOrder>>) => {
            state.isLoading = false;
            state.error = '';
            state.orders = action.payload;
        },
        [fetchOrders.pending.type]: (state) => {
            state.isLoading = true;
        },
        [fetchOrders.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [getOrderById.fulfilled.type]: (state, action: PayloadAction<IOrderDetails>) => {
            state.isLoading = false;
            state.error = '';
            state.order = action.payload;
        },
        [getOrderById.pending.type]: (state) => {
            state.isLoading = true;
        },
        [getOrderById.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [createOrder.fulfilled.type]: (state, action: PayloadAction<IOrder>) => {
            state.isLoading = false;
            state.error = '';
            state.orders = [...state.orders,  action.payload];
        },
        [createOrder.pending.type]: (state) => {
            state.isLoading = true;
        },
        [createOrder.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [updateOrder.fulfilled.type]: (state, action: PayloadAction<IOrder>) => {
            state.isLoading = false;
            state.error = '';
            state.orders = state.orders.map((item) => item.id === action.payload.id ? action.payload : item);
        },
        [updateOrder.pending.type]: (state) => {
            state.isLoading = true;
        },
        [updateOrder.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [deleteOrder.fulfilled.type]: (state, action: any) => {
            state.isLoading = false;
            state.error = '';
            state.orders = state.orders.filter(x => x.id !== action.meta.arg);
        },
        [deleteOrder.pending.type]: (state) => {
            state.isLoading = true;
        },
        [deleteOrder.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
    }
})

export default orderSlice.reducer;
