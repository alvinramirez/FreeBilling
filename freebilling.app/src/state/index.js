import { reactive } from "vue";
import axios from "axios";

export default reactive({
    token: "",
    customers: [],
    employees: [],
    timeBills: [],
    currentCustomer: null,
    async loadCustomers() {
        if (this.customers.length == 0) {
            const customerResult = await axios.get("/api/customers", {
                headers: {
                    "Authorization": `Bearer ${this.token}`
                }
            });
            this.customers.splice(this.customers, this.customers.length, ...customerResult.data);
        }
    }
});