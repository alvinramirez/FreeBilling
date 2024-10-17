// router
import HomeView from "@/views/HomeView.vue";
import BillingView from "@/views/BillingView.vue";
import { createRouter, createWebHistory } from "vue-router";

const routes = [
    {
        path: "/",
        name: "Home",
        component: HomeView
    },
    {
        path: "/billing",
        name: "Billing",
        component: BillingView
    }

];

const router = createRouter({
    routes,
    history: createWebHistory()
});

export default router;