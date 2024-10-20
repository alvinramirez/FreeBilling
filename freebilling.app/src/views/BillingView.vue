<script setup>
    import { ref } from "vue";
    const bill = ref({});

    const message = ref("");
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
                <option>Pick One...</option>
                <option value="1">Dave</option>
                <option value="2">Phil</option>
                <option value="3">Hank</option>
            </select>
            <label for="rate">Rate</label>
            <input type="number" id="rate" v-model="bill.rate"/>
            <label for="client">Client</label>
            <select id="client" name="client" v-model="bill.clientId">
                <option>Pick One...</option>
                <option value="1">Smith Towing</option>
                <option value="2">Jakes Mufflers</option>
                <option value="3">Paintorama</option>
            </select>
            <div class="mt-2">
                <button type="submit" class="bg-green-800 hover:bg-green-700 mr-2">Save</button>
                <button type="submit">Save</button>
            </div>
        </form>
        <pre>{{ bill }}</pre>
    </div>
</template>