import axios from "axios";
import { axiosConfig } from '../config/axiosConfig';
import AuthService from "./AuthService";

const axiosInstance = axios.create({
    baseURL: axiosConfig.baseURL,
    });

    axiosInstance.interceptors.request.use(
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

export default axiosInstance;