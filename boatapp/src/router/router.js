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
  {
    path: "/boat/:id",
    name: "boat",
    component: () => import("../pages/boat/update.vue"),
    beforeEnter: requireAuth,
  },
  {
    path: "/boat/submit",
    name: "boatsubmission",
    component: () => import("../pages/boat/submission.vue"),
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
