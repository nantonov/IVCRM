import { combineReducers, configureStore } from '@reduxjs/toolkit';
import customerReducer from './reducers/customers/CustomerSlice'
import categoryReducer from './reducers/categories/CategorySlice'
import authReducer from './reducers/auth/AuthSlice'

const rootReducer = combineReducers({
    customerReducer,
    categoryReducer,
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