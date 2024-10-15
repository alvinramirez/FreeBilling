<template>
    <ul class="text-blue-900 font-bold flex">
        <li><RouterLink :to="{ name: 'Home' }">Home</RouterLink></li>
        <li><RouterLink :to="{ name: 'Billing' }">Billing</RouterLink></li>
    </ul>

    <div class="bg-gray-300 p-2">
        <RouterView></RouterView>
    </div>

</template>