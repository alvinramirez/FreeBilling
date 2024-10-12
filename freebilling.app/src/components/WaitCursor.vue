<script setup>

    defineProps({
        "busy": { required: true, type: Boolean },
        "msg": { type: String, default: "Loading..." }
    });

</script>

<template>
    <div v-if="busy" class="bg-blue-900 text-white p-2 text-lg">{{ msg }}</div>
</template>