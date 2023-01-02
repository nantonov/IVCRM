import OrderService from "../../../services/OrderService";
import { createAsyncThunk } from "@reduxjs/toolkit";
import { IChangeOrder } from "../../../models/IChangeOrder";

export const fetchOrders = createAsyncThunk(
    'order/getAll',
    async (_, thunkAPI) => { 
        try {
            const response = await OrderService.getAll()
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)

export const getOrderById = createAsyncThunk(
    'order/getById',
    async (id: number, thunkAPI) => { 
        try {
            const response = await OrderService.getById(id)
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)

export const createOrder = createAsyncThunk(
    'order/create',
    async (order :IChangeOrder, thunkAPI) => { 
        try {
            const response = await OrderService.create(order)
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)

export const updateOrder = createAsyncThunk(
    'order/update',
    async (order :IChangeOrder, thunkAPI) => { 
        try {
            const response = await OrderService.update(order)
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)

export const deleteOrder = createAsyncThunk(
    'order/delete',
    async (id :number, thunkAPI) => { 
        try {
            const response = await OrderService.delete(id)
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)
