import axios from "axios";
import corsProxy from "./corsSetting.js";
import router from "./router.js";

export const api = axios.create({
    baseURL: import.meta.env.VITE_EPIDEMIC_URL
});

api.interceptors.request.use((config) => {
    // Construct the full URL manually
    const fullUrl = new URL(config.url, config.baseURL);

    // Append query params manually if present
    if (config.params) {
        Object.entries(config.params).forEach(([key, value]) => {
            if (value)
                fullUrl.searchParams.append(key, value);
        });
    }

    // URL-encode the entire URL
    const encodedUrl = encodeURIComponent(fullUrl.toString());

    // Replace the config to use the proxy + encoded URL
    config.baseURL = ''; // Clear baseURL so axios uses the full URL
    config.url = corsProxy.value + encodedUrl;

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