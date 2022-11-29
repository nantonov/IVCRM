import { combineReducers, configureStore } from '@reduxjs/toolkit';
import customerReducer from './reducers/customers/CustomerSlice'
import authReducer from './reducers/auth/AuthSlice'

const rootReducer = combineReducers({
    customerReducer,
    authReducer,
})

export const setupStore = () => {
    return configureStore({
        reducer: rootReducer
    })
}

export type RootState = ReturnType<typeof rootReducer>
export type AppStore = ReturnType<typeof setupStore>
export type AppDispatch = AppStore['dispatch']