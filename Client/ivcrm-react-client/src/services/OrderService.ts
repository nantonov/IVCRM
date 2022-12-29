import { IChangeOrder } from "../models/IChangeOrder";
import { IOrder } from "../models/IOrder";
import axiosInstance from "./AxiosInstance";

export default class OrderService {
    static async create(order: IChangeOrder) {
        const response = await axiosInstance.post<IOrder>(`/order`, order)
        return response.data;
    }

    static async update(order: IChangeOrder) {
        const response = await axiosInstance.put<IOrder>(`/order/${order.id}`, order)
        return response.data;
    }

    static async delete(id: number) {
        const response = await axiosInstance.delete(`/order/${id}`)
        return response;
    }

    static async getAll() {
        const response = await axiosInstance.get<Array<IOrder>>(`/order`)
        return response.data;
    }

    static async getById(id: number) {
        const response = await axiosInstance.get<Array<IOrder>>(`/order/${id}`)
        return response.data;
    }
}
 