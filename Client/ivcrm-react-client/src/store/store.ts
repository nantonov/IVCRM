import { combineReducers, configureStore } from '@reduxjs/toolkit';
import customerReducer from './reducers/customers/CustomerSlice'
import categoryReducer from './reducers/categories/CategorySlice'
import authReducer from './reducers/auth/AuthSlice'
import productReducer from './reducers/products/ProductSlice'

const rootReducer = combineReducers({
    customerReducer,
    categoryReducer,
    productReducer,
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