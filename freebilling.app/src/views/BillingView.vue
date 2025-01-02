<script setup>
    import { ref, reactive, onMounted } from "vue";
    import axios from "axios"; 
    import state from "@/state";
    import { useRouter } from "vue-router";

    const router = useRouter();
    const bill = ref({});
    const employees = reactive([]);
    const customers = reactive([]);
    const message = ref("");

    onMounted(async () => {
    try {
            await state.loadCustomers();
            await state.loadEmployees();
        }
        catch (e)
        {
            if (e.response && e.response.status === 401) {
            message.value = "Unauthorized: Por favor intentalo otra vez.";
            router.push("/login");
            }
            else
            {
                message.value = e.message || "Ha ocurrido un error.";
            }
        }
    });


</script>

<template>
    <div class="w-96 mx-auto bg-white p-2">
        <h1>Billing</h1>
        <div v-if="message">{{ message }}</div>
        <form novalidate>
            <label for="time">Time</label>
            <input type="text" name="time" id="time" v-model="bill.hoursWorked" />
            <label for="workPerformed">Work Performed</label>
            <textarea rows="4" name="workPerformed" id="workPerformed" v-model="bill.work"></textarea>
            <label for="employee">Employee</label>
            <select id="employee" name="client" v-model="bill.employeeId">
                <option v-for="e in employees" :accesskey="e.id" :value="e.id">{{ e.name }}</option>
            </select>
            <label for="rate">Rate</label>
            <input type="number" id="rate" v-model="bill.rate"/>
            <label for="client">Client</label>
            <select id="client" name="client" v-model="bill.clientId">
                <option>Pick One...</option>
                <option v-for="c in state.customers" :value="c.Id" :key="c.Id">{{ c.companyName}}</option>
            </select>
            <div class="mt-2">
                <button type="submit" class="bg-green-800 hover:bg-green-700 mr-2">Save</button>
                <button type="submit">Save</button>
            </div>
        </form>
        <pre>{{ bill }}</pre>
    </div>
</template>