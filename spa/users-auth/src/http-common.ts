import axios, { AxiosInstance } from "axios";

const apiClient: AxiosInstance = axios.create({
    baseURL: "https://localhost:7108/api/auth",
    headers: {
        // "Content-type": "application/json",
    },
});

export default apiClient;
