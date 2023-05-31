import { createApp } from "vue";
import "./style.css";
import App from "./App.vue";
import router from "./router/router";
import store from "./store/store";

import axios from "axios";
import VueAxios from "vue-axios";


const app = createApp(App);
// Make sure to _use_ the router instance to make the
// whole app router-aware.
app.use(store);
app.use(router);
app.use(VueAxios, axios);

app.mount("#app");
