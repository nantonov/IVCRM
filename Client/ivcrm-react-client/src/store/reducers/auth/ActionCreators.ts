import { createAsyncThunk } from "@reduxjs/toolkit";
import { IChangeCustomer } from "../../../models/IChangeCustomer";
import AuthService from "../../../services/AuthService";

export const getUser = createAsyncThunk(
    'auth/user',
    async (_, thunkAPI) => { 
        try {
            const response = await AuthService.getUser()
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)

export const signIn = createAsyncThunk(
    'auth/signIn',
    async (_, thunkAPI) => { 
        try {
            const response = await AuthService.signIn()
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)

export const signOut = createAsyncThunk(
    'auth/signOut',
    async (_, thunkAPI) => { 
        try {
            const response = await AuthService.signOut()
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)
