import axios from "axios";
import { IChangeCustomer } from "../models/IChangeCustomer";
import { ICustomer } from "../models/ICustomer";
import { axiosConfig } from '../config/axiosConfig';
import AuthService from "./AuthService";

const instance = axios.create({
    baseURL: axiosConfig.baseURL,
    });

    instance.interceptors.request.use(
        async function (config: any) {
          const token = await AuthService.getUser().then((user) => {
            return user?.access_token;
          });
          if (token) config.headers.Authorization = `Bearer ${token}`;
          return config;
        },
        function (error) {
          return Promise.reject(error);
        }
      );

export default class CustomerService {
    static async create(customer: IChangeCustomer) {
        const response = await instance.post<ICustomer>(`/customer`, customer)
        return response.data;
    }

    static async update(customer: IChangeCustomer) {
        const response = await instance.put<ICustomer>(`/customer/${customer.id}`, customer)
        return response.data;
    }

    static async delete(id: number) {
        const response = await instance.delete(`/customer/${id}`)
        return response;
    }
    
    static async getAll() {
        const response = await instance.get<Array<ICustomer>>(`/customer`)
        return response.data;
    }
}
 