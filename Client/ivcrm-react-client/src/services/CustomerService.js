import axios from "axios";

export default class CustomerService {
    static async create(customer) {
        const response = await axios.post(`https://localhost:7159/api/customer`, customer)
        return response.data;
    }

    static async update(customer) {
        const response = await axios.put(`https://localhost:7159/api/customer/${customer.id}`, customer)
        return response.data;
    }

    static async delete(id) {
        const response = await axios.delete(`https://localhost:7159/api/customer/${id}`)
        return response;
    }
    
    static async getAll() {
        const response = await axios.get(`https://localhost:7159/api/customer`)
        return response.data;
    }
}
 