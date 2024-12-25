<script setup>
    import state from "@/state";
    import { useRouter } from "vue-router";
    import router from "./router/index";

    function logout() {
        state.token = "";
        router.push("/");
    }
</script>

<template>
    <ul class="text-blue-900 font-bold flex justify-end mr-2">
        <li><RouterLink :to="{ name: 'Home' }">Home</RouterLink></li>
        <li><RouterLink :to="{ name: 'Billing' }">Billing</RouterLink></li>
        <li><RouterLink v-if="!state.token" :to="{ name: 'Login' }">Login</RouterLink></li>
        <li><a href="" v-if="state.token" @click="logout">Logout</a></li>
    </ul>

    <div class="bg-gray-300 p-2">
        <RouterView></RouterView>
    </div>

</template>