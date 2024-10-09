<script setup>
    import { ref, reactive, computed } from "vue";
    import { formatMoney } from "./formatters";

    const name = ref("Alvin");

    const nancy = ref("Nancy Smith");

    const bills = reactive([
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
    ]);

    const total = computed(() => {
        return bills.map(b => b.rate * b.hoursWorked)
                    .reduce((b, t) => t + b, 0)    ;
    })

    function changeMe()
    {
        name.value += "+";
        //alert(name);
    }

    function newItem()
    {
        bills.push({
            customerId: 1,
            employeeId: 1,
            hoursWorked: 5.0,
            rate: 114,
            work: "More work",
            date: "2023-05-08"
        });

        console.log(bills.length);
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
      <img src="../../imgs/nancy.jpg" :alt="nancy" :title="nancy"/>
      <button class="btn" @click="newItem">New Item</button>
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
      <div>Total: {{ formatMoney(total) }}</div>
  </main>
</template>