import "./style.scss";
import { store } from "./store/CountryStore";
import { createApp } from "vue";
import App from "./App.vue";

createApp(App).use(store).mount("#app");
