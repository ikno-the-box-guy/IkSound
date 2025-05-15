import {useStorage} from "@vueuse/core";

const corsProxy = useStorage(
    'cors-proxy-url',
    'https://ikcors.azurewebsites.net/api/proxy/',
    localStorage,
    {
        mergeDefaults: true,
    },
)

export default corsProxy;