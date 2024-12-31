// http.js
import axios from "axios";
import state from "/@state";

export default {
    async get(url) {
        return await axios.get(url, {
            headers: {
                Authorization: `Bearer ${this.state.token}`
            }
        });
    }
}