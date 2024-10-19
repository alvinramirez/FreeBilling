<template>
    <div class="w-96 mx-auto bg-white p-2">
        <h1>Billing</h1>
        <form novalidate>
            <label for="time">Time</label>
            <input type="text" name="time" id="time" />
            <label for="workPerformed">Work Performed</label>
            <textarea rows="4" name="workPerformed" id="workPerformed"></textarea>
            <label for="employee">Employee</label>
            <select id="employee" name="client">
                <option>Pick One...</option>
                <option>Dave</option>
                <option>Phil</option>
                <option>Hank</option>
            </select>
            <label for="rate">Rate</label>
            <input type="number" id="rate" />
            <label for="client">Client</label>
            <select id="client" name="client">
                <option>Pick One...</option>
                <option>Smith Towing</option>
                <option>Jakes Mufflers</option>
                <option>Paintorama</option>
            </select>
            <div class="mt-2">
                <button type="submit" class="bg-green-800 hover:bg-green-700 mr-2">Save</button>
                <button type="submit">Save</button>
            </div>
        </form>
    </div>
</template>