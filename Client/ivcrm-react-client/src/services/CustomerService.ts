import { IChangeCustomer } from "../models/IChangeCustomer";
import { ICustomer } from "../models/ICustomer";
import { IPagedList } from "../models/IPagedList";
import { ITableParameters } from "../models/ITableParameters";
import axiosInstance from "./AxiosInstance";

export default class CustomerService {
    static async create(customer: IChangeCustomer) {
        const response = await axiosInstance.post<ICustomer>(`/customer`, customer)
        return response.data;
    }

    static async update(customer: IChangeCustomer) {
        const response = await axiosInstance.put<ICustomer>(`/customer/${customer.id}`, customer)
        return response.data;
    }

    static async delete(id: number) {
        const response = await axiosInstance.delete(`/customer/${id}`)
        return response;
    }
    
    static async getAll(tableParams: ITableParameters) {
        const response = await axiosInstance.get<IPagedList<ICustomer>>(`/customer?pageNumber=${tableParams.pageNumber}&pageSize=${tableParams.pageSize}`)
        return response.data;
    }

    static async getById(id: number) {
        const response = await axiosInstance.get<ICustomer>(`/customer/${id}`)
        return response.data;
    }
}
 