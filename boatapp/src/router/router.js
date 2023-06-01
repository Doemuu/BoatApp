import store from "../store/store";
import { createRouter, createWebHistory } from "vue-router";

const routes = [
  {
    path: "/auth",
    name: "Login",
    component: () => import("../pages/authentication.vue"),
  },
  {
    path: "/",
    name: "home",
    component: () => import("../pages/index.vue"),
    beforeEnter: requireAuth,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

function requireAuth(to) {
  if (localStorage.getItem("username") === null && to.name !== "Login") {
    return { name: "Login" };
  }
}

export default router;
