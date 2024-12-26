// router
import HomeView from "@/views/HomeView.vue";
import BillingView from "@/views/BillingView.vue";
import LoginView from "@/views/LoginView.vue";
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
    },
    {
        path: "/login",
        name: "Login",
        component: LoginView
    }

];

const router = createRouter({
    routes,
    history: createWebHistory()
});

router.beforeEach((to) => {
    if (to.name !== "Login")
    {  
        if (!state.token)
        {
            return { name: "Login"}
        }
    }
});

export default router;