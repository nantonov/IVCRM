import { createSlice, PayloadAction } from "@reduxjs/toolkit"
import {  getUser, signIn, signOut, } from "./ActionCreators";
import { User } from "oidc-client";

interface IUserState {
    user: User;
    isAuth: boolean;
    isLoading: boolean;
    error: string;
}

const initialState: IUserState = {
    user: {} as User,
    isAuth: false,
    isLoading: false,
    error: '',
}

export const userSlice = createSlice({
    name: 'user',
    initialState,
    reducers: {},
    extraReducers: {
        [getUser.fulfilled.type]: (state, action: PayloadAction<User>) => {
            state.isLoading = false;
            state.error = '';
            state.user = action.payload;
            if(state.user != null)
            {
                state.isAuth = true;
            }
        },
        [getUser.pending.type]: (state) => {
            state.isLoading = true;
        },
        [getUser.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.isAuth = false;
            state.error = action.payload;
        },
        [signIn.fulfilled.type]: (state, action: PayloadAction<User>) => {
            state.isLoading = false;
            state.error = '';
            state.user = action.payload;
        },
        [signIn.pending.type]: (state) => {
            state.isLoading = true;
        },
        [signIn.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [signOut.fulfilled.type]: (state, action: PayloadAction<User>) => {
            state.isLoading = false;
            state.error = '';
            state = initialState;
        },
        [signOut.pending.type]: (state) => {
            state.isLoading = true;
        },
        [signOut.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
    }
})

export default userSlice.reducer;
