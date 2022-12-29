import CustomerService from "../../../services/CustomerService";
import { createAsyncThunk } from "@reduxjs/toolkit";
import { IChangeCustomer } from "../../../models/IChangeCustomer";
import { ITableParameters } from "../../../models/ITableParameters";

export const fetchCustomers = createAsyncThunk(
    'customer/getAll',
    async (params: ITableParameters, thunkAPI) => { 
        try {
            const response = await CustomerService.getAll(params)
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)

export const createCustomer = createAsyncThunk(
    'customer/create',
    async (customer :IChangeCustomer, thunkAPI) => { 
        try {
            const response = await CustomerService.create(customer)
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)

export const updateCustomer = createAsyncThunk(
    'customer/update',
    async (customer :IChangeCustomer, thunkAPI) => { 
        try {
            const response = await CustomerService.update(customer)
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)

export const deleteCustomer = createAsyncThunk(
    'customer/delete',
    async (id :number, thunkAPI) => { 
        try {
            const response = await CustomerService.delete(id)
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)
