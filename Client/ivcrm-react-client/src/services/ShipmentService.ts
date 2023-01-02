import { IChangeShipment } from "../models/IChangeShipment";
import { IShipment } from "../models/IShipment";
import axiosInstance from "./AxiosInstance";

export default class ShipmentService {
    static async create(shipment: IChangeShipment) {
        const response = await axiosInstance.post<IShipment>(`/shipment`, shipment)
        return response.data;
    }

    static async getByOrderId(orderId: number) {
        const response = await axiosInstance.get<Array<IShipment>>(`/shipment/order/${orderId}`)
        return response.data;
    }
}
 