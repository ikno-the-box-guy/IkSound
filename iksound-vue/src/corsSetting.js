import {useStorage} from "@vueuse/core";
import {api} from "./api.js";

const corsProxy = useStorage(
    'cors-proxy',
    'https://cors-anywhere-64h4.onrender.com/',
    localStorage,
    {
        mergeDefaults: true,
    },
)

export default corsProxy;