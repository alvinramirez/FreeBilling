/* eslint-disable no-undef */
import { reactive } from "vue";
import axios from "axios";

export default reactive({
    token: "",
    customers: [],
    employees: [],
    timeBills: [],
    currentCustomer: null,
    async loadCustomers() {
        if (this.customers.length === 0) {
            const customerResult = await axios.get("/api/customers", {
                headers: {
                    "Authorization": `Bearer ${this.token}`
                }
            });
            this.customers.splice(this.customers, this.customers.length, ...customerResult.data);
        }
    },
    async loadEmployees() {
        if (this.employees.length === 0) {
            const employeesResult = await axios.get("/api/employees", {
                headers: {
                    Authorization: `Bearer ${this.state.token}`
                }
            });
            this.employees.splice(this.employees, this.employees.length, ...employeesResult.data);
        }
    },
    async loadTimeBills(customerId) {
        this.currentCustomerId = customerId;    
        const result = await axios.get(`/api/customers/${this.currentCustomerId}/timebills`);
        if (result.status === 200) {
            this.state.timebills.splice(0, this.state.timebills.length, ...result.data);
        }
    },
    async saveBill(bill) {
        const result = await http.post("/api/timebills", bill);
        if (result.status === 201)
        {
            if (result.data.customerId === this.currentCustomerId)
            {
                this.timeBills.push(result.data);
            }
        }
    }
});