import { IChangeProductCategory } from "../models/IChangeProductCategory";
import { IProductCategory } from "../models/IProductCategory";
import axiosInstance from "./AxiosInstance";

export default class ProductCategoryService {
    static async create(customer: IChangeProductCategory) {
        const response = await axiosInstance.post<IProductCategory>(`/productCategory`, customer)
        return response.data;
    }

    static async update(customer: IChangeProductCategory) {
        const response = await axiosInstance.put<IProductCategory>(`/productCategory/${customer.id}`, customer)
        return response.data;
    }

    static async delete(id: number) {
        const response = await axiosInstance.delete(`/productCategory/${id}`)
        return response;
    }
    
    static async getAll() {
        const response = await axiosInstance.get<Array<IProductCategory>>(`/productCategory`)
        return response.data;
    }
}
 