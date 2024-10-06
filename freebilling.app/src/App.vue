<script setup>
    import { ref } from "vue";

    const name = ref("Alvin");

    const nancy = ref("Nancy Smith");

    const bills = [
        {
            "hoursWorked": 3.0,
            "rate": 225.00,
            "date": "2024-05-05",
            "work": "I did a thing...",
            "customerId": 1,
            "employeeId": 1
        },
        {
            "hoursWorked": 2.0,
            "rate": 105.00,
            "date": "2024-05-06",
            "work": "I did another thing...",
            "customerId": 1,
            "employeeId": 1
        },
        {
            "hoursWorked": 9.0,
            "rate": 140.00,
            "date": "2024-05-07",
            "work": "I finish a thing...",
            "customerId": 1,
            "employeeId": 1
        }
    ];

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
      <table>
          <thead>
              <tr>
                  <td>Hours</td>
                  <td>Date</td>
                  <td>Description</td>
              </tr>
          </thead>
          <tbody>
              <tr v-for="b in bills">
                  <td>{{ b.hoursWorked }}</td>
                  <td>{{ b.date }}</td>
                  <td>{{ b.work }}</td>
              </tr>
          </tbody>
      </table>
  </main>
</template>