import axios from "axios";
import corsProxy from "./corsSetting.js";
import router from "./router.js";

export const api = axios.create({
    baseURL: import.meta.env.VITE_EPIDEMIC_URL
});

api.interceptors.request.use((config) => {
    config.baseURL = corsProxy.value + config.baseURL
    return config;
});

api.interceptors.response.use((response) => {
    return response;
}, (error) => {
    if (error.message === 'Network Error' && !error.response) {
        router.push({
            path: '/cors',
            query: { error: true, from: router.currentRoute.value.fullPath }
        }).then()
    }

    return Promise.reject(error);
});