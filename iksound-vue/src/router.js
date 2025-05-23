﻿import {createWebHistory, createRouter, createWebHashHistory} from 'vue-router'
import HomePage from "./pages/HomePage.vue";
import NotFoundPage from "./pages/NotFoundPage.vue";
import SoundsPage from "./pages/search/SoundsPage.vue";
import MusicPage from "./pages/search/MusicPage.vue";
import SearchPage from "./pages/search/SearchPage.vue";
import CorsInfoPage from "./pages/CorsInfoPage.vue";
import TrackPage from "./pages/TrackPage.vue";

const routes = [
    { path: '/', component: HomePage },
    { path: '/sounds', component: SoundsPage },
    { path: '/music', component: MusicPage },
    { path: '/search', component: SearchPage },
    { path: '/track/:id', component: TrackPage },
    { path: '/cors', component: CorsInfoPage },
    { path: '/:pathMatch(.*)*', component: NotFoundPage },
]

const router = createRouter({
    history: createWebHashHistory(import.meta.env.BASE_URL + "/#/"),
    routes,
})

export default router