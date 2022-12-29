import { IShipment } from "../../../models/IShipment";
import { createSlice, PayloadAction } from "@reduxjs/toolkit"
import { createShipment, fetchShipment } from "./ActionCreators";

interface IShipmentState {
    shipments: IShipment[];
    isLoading: boolean;
    error: string;
}

const initialState: IShipmentState = {
    shipments: [],
    isLoading: false,
    error: '',
}

export const shipmentSlice = createSlice({
    name: 'order',
    initialState,
    reducers: {},
    extraReducers: {
        [fetchShipment.fulfilled.type]: (state, action: PayloadAction<Array<IShipment>>) => {
            state.isLoading = false;
            state.error = '';
            state.shipments = action.payload;
        },
        [fetchShipment.pending.type]: (state) => {
            state.isLoading = true;
        },
        [fetchShipment.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [createShipment.fulfilled.type]: (state, action: PayloadAction<IShipment>) => {
            state.isLoading = false;
            state.error = '';
            state.shipments = [...state.shipments,  action.payload];
        },
        [createShipment.pending.type]: (state) => {
            state.isLoading = true;
        },
        [createShipment.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        }
    }
})

export default shipmentSlice.reducer;
