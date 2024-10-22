<script setup>
    import { ref } from "vue";
    import axios from "axios";
    import state from "@/state";
    import { useRouter } from "vue-router";

    const username = ref("");
    const password = ref("");
    const message = ref("");

    const router = useRouter();

    async function login() {
        try {
            const result = await axios.post("/api/auth/token", {
                username: username.value,
                password: password.value
            })
            state.token = result.data.token;
            router.push("/");
        } catch {
            message.value = "Wrong username or password";
        }
    }
</script>

<template>
    <div class="w-96 mx-auto p-6 bg-white shadow-md rounded">
        <h3 class="text-2x1 mb-4 text-center">Login</h3>
        <form novalidate @submit.prevent="login">

        <div v-if="message" class="mb-4 text-red-500 text-center">{{ message }}</div>

        <div class="mb-4">
            <label for="username" class="block mb-1 font-semibold">Username</label>
            <input type="text"
                   id="username"
                   v-model="username"
                   class="w-full px-3 py-2 border rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
                   placeholder="Username" />
        </div>

        <div class="mb-6">
            <label for="password" class="block mb-1 font-semibold">Password</label>
            <input type="password"
                   id="password"
                   v-model="password"
                   class="w-full px-3 py-2 border rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
                   placeholder="Password" />
        </div>

        <button type="submit"
                @click="login"
                class="w-full bg-blue-500 text-white py-2 rounded hover:bg-blue-600 transition duration-1000">
                Login
        </button>
        </form>
    </div>
</template>