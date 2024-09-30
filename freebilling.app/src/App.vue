<script setup>
    let name = "Alvin";
    function changeMe()
    {
        name = "Ivis";
        alert(name);
    }
</script>

<template>
  <header class="flex text-red-900">
      <h3>Our App</h3>
  </header>

  <main>
      <h1>Hello from Vue</h1>
      <div>{{ name }}</div>
      <button class="btn" @click="changeMe">Change Me</button>
  </main>
</template>