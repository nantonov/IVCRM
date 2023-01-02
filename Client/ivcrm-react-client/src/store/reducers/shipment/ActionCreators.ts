import ShipmentService from "../../../services/ShipmentService";
import { createAsyncThunk } from "@reduxjs/toolkit";
import { IChangeShipment } from "../../../models/IChangeShipment";

export const fetchShipment = createAsyncThunk(
    'shipment/getByOrderId',
    async (orderId: number, thunkAPI) => { 
        try {
            const response = await ShipmentService.getByOrderId(orderId)
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)

export const createShipment = createAsyncThunk(
    'shipment/create',
    async (shipment :IChangeShipment, thunkAPI) => { 
        try {
            const response = await ShipmentService.create(shipment)
            return response;
        } catch (e: any) {
            return thunkAPI.rejectWithValue(e.response.data);
        }
    }
)
