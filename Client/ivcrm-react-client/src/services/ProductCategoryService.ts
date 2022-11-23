import axios from "axios";
import { IChangeProductCategory } from "../models/IChangeProductCategory";
import { IProductCategory } from "../models/IProductCategory";
import { axiosConfig } from '../config/axiosConfig';
import AuthService from "./AuthService";

const instance = axios.create({
    baseURL: axiosConfig.baseURL,
    });

instance.interceptors.request.use(
    async (config: any) => {
        const token = await AuthService.getUser().then((user) => {
        return user?.access_token;
        });
        if (token) config.headers.Authorization = `Bearer ${token}`;
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

export default class ProductCategoryService {
    static async create(customer: IChangeProductCategory) {
        const response = await instance.post<IProductCategory>(`/productCategory`, customer)
        return response.data;
    }

    static async update(customer: IChangeProductCategory) {
        const response = await instance.put<IProductCategory>(`/productCategory/${customer.id}`, customer)
        return response.data;
    }

    static async delete(id: number) {
        const response = await instance.delete(`/productCategory/${id}`)
        return response;
    }
    
    static async getAll() {
        const response = await instance.get<Array<IProductCategory>>(`/productCategory`)
        return response.data;
    }
}
 