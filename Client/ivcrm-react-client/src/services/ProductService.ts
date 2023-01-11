import { IChangeProduct } from "../models/IChangeProduct";
import { IPictureModel } from "../models/IPictureModel";
import { IProduct } from "../models/IProduct";
import axiosInstance from "./AxiosInstance";

export default class ProductService {
    static async create(product: IChangeProduct) {
        const response = await axiosInstance.post<IProduct>(`/product`, product)
        return response.data;
    }

    static async update(product: IChangeProduct) {
        const response = await axiosInstance.put<IProduct>(`/product/${product.id}`, product)
        return response.data;
    }

    static async delete(id: number) {
        const response = await axiosInstance.delete(`/product/${id}`)
        return response;
    }

    static async getAll() {
        const response = await axiosInstance.get<Array<IProduct>>(`/product`)
        return response.data;
    }

    static async getById(id: number) {
        const response = await axiosInstance.get<IProduct>(`/product/${id}`)
        return response.data;
    }

    static async uploadPicture(picture: IPictureModel) {
        console.log(picture)
        const response = await axiosInstance.post(`/product/picture`, picture, {
            headers: {
                'Content-Type': 'multipart/form-data'
            }
        })
        return response;
    }
}
 