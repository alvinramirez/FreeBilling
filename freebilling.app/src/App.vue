<script setup>
    import { ref } from "vue";

    const name = ref("Alvin");

    const nancy = ref("Nancy Smith");

    function changeMe()
    {
        name.value += "+";
        //alert(name);
    }
</script>

<template>
  <header class="flex" style="color: #900;">
      <h3>Our App</h3>
  </header>

  <main>
      <h1>Hello from Vue</h1>
      <div>{{ name }}</div>
      <button class="btn" @click="changeMe">Change Me</button>
      <img src="/nancy.jpg" :alt="nancy" :title="nancy"/>
  </main>
</template>