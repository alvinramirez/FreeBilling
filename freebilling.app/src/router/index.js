// router
import HomeView from "@/views/HomeView.vue";
import BillingView from "@/views/BillingView.vue";
import { createRouter, createWebHashHistory, createWebHistory } from "vue-router";

const routes = [
    {
        name: "Home",
        path: "/",
        component: HomeView
    },
    {
        path: "/billing",
        component: BillingView
    }

];

const router = createRouter({
    routes,
    history: createWebHistory()
});

export default router;