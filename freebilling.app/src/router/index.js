// router
import HomeView from "../views/HomeView.vue"
import { createRouter, createWebHashHistory, createWebHistory } from "vue-router";

const routes = [
    {
        path: "/",
        component: HomeView
    }
];

const router = createRouter({
    routes,
    history: createWebHistory()
});

export default router;