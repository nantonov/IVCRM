import { combineReducers, configureStore } from '@reduxjs/toolkit';
import customerReducer from './reducers/customers/CustomerSlice'
import categoryReducer from './reducers/categories/CategorySlice'
import orderReducer from './reducers/orders/OrderSlice'
import shipmentReducer from './reducers/shipment/ShipmentSlice'
import authReducer from './reducers/auth/AuthSlice'
import productReducer from './reducers/products/ProductSlice'
import modalReducer from './reducers/modal/ModalSlice'

const rootReducer = combineReducers({
    modalReducer,
    customerReducer,
    categoryReducer,
    productReducer,
    orderReducer,
    shipmentReducer,
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