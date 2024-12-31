<script setup>
    import { ref, reactive, computed, onMounted, watch } from "vue";
    import { formatMoney } from "@/formatters";
    import axios from "axios";
    import WaitCursor from "@/components/WaitCursor.vue";
    import state from "@/state";

    const name = ref("Alvin");

    const nancy = ref("Nancy Smith");

    const isBusy = ref(false);

    const customerId = ref(0);

    onMounted(async () => {
        try {
            isBusy.value = true;
            await state.loadCustomers();
            
        } catch {
            console.log("Failed");
        } finally {
            setTimeout(() => isBusy.value = false, 1000);
        }
    });

    const total = computed(() => {
        return state.timeBills.map(b => b.billingRate * b.hours)
                    .reduce((b, t) => t + b, 0);
    })

    watch(customerId, async () => {
        try {
            isBusy.value = true;
            state.loadTimeBills(customerId.value);
        } catch {
            isBusy.value = false;
        }
    });

    function changeMe()
    {
        name.value += "+";
        //alert(name);
    }

    function newItem()
    {
        state.timeBills.push({
            customerId: 1,
            employeeId: 1,
            hoursWorked: 5.0,
            rate: 114,
            work: "More work",
            date: "2024-05-08"
        });

        console.log(state.timeBills.length);
    }
</script>

<template>
    <header class="flex" style="color: #900;">
        <h3>Our App</h3>
    </header>

    <main>
        <h1>Hello from Vue</h1>
        <WaitCursor :busy="isBusy" msg="Please wait..."></WaitCursor>
        <!--<div>{{ name }}</div>
        <button class="btn" @click="changeMe">Change Me</button>
        <img src="../../imgs/nancy.jpg" :alt="nancy" :title="nancy"/>
        <button class="btn" @click="newItem">New Item</button>-->
        <div>
            Customers: 
            <select class="w-96 mx-2" v-model="customerId">
                <option v-for="c in state.customers :value="c.id">{{ c.companyName }}</option>
            </select>
        </div>
        <table class="w-full">
            <thead>
                <tr>
                    <td>Hours</td>
                    <td>Date</td>
                    <td>Description</td>
                    <td>Rate</td>
                    <td>Employee</td>
                </tr>
            </thead>
            <tbody>
                <tr v-for="b in state.timeBills">
                    <td>{{ b.hours }}</td>
                    <td>{{ b.date }}</td>
                    <td>{{ b.workPerformed }}</td>
                    <td>{{ b.billingRate }}</td>
                    <td>{{ b.employee.name }}</td>
                </tr>
            </tbody>
        </table>
        <div>Total: {{ formatMoney(total) }}</div>
    </main>
</template>