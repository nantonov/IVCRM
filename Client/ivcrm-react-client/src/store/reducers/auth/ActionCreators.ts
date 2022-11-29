import { createAsyncThunk } from "@reduxjs/toolkit";
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
            const response = await AuthService.signInCallback()
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
            const response = await AuthService.signOutCallback()
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)
