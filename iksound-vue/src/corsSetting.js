import {useStorage} from "@vueuse/core";
import {api} from "./api.js";

const corsProxy = useStorage(
    'cors-proxy',
    'https://corsproxy.io/?',
    localStorage,
    {
        mergeDefaults: true,
    },
)

export default corsProxy;