import axios from "axios";
import { IChangeCustomer } from "../models/IChangeCustomer";
import { ICustomer } from "../models/ICustomer";

export default class CustomerService {
    static async create(customer: IChangeCustomer) {
        const response = await axios.post<ICustomer>(`https://localhost:7159/api/customer`, customer)
        return response.data;
    }

    static async update(customer: IChangeCustomer) {
        const response = await axios.put<ICustomer>(`https://localhost:7159/api/customer/${customer.id}`, customer)
        return response.data;
    }

    static async delete(id: number) {
        const response = await axios.delete(`https://localhost:7159/api/customer/${id}`)
        return response;
    }
    
    static async getAll() {
        const response = await axios.get<Array<ICustomer>>(`https://localhost:7159/api/customer`)
        return response.data;
    }
}
 