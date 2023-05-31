import store from "../store/store";
import { createRouter, createWebHistory } from "vue-router";
import HelloWorld from "../components/HelloWorld.vue";

const Home = { template: HelloWorld };
const About = { template: "<div>About</div>" };

// 2. Define some routes
// Each route should map to a component.
// We'll talk about nested routes later.
const routes = [
  {
    path: "/auth",
    name: "Login",
    component: () => import("../pages/authentication.vue"),
  },
  { path: "/", component: HelloWorld, beforeEnter: requireAuth },
  { path: "/about", component: HelloWorld, beforeEnter: requireAuth },
];

// 3. Create the router instance and pass the `routes` option
// You can pass in additional options here, but let's
// keep it simple for now.
const router = createRouter({
  history: createWebHistory(),
  routes,
});

function requireAuth(to) {
  if (store.state.user.id === undefined && to.name !== "Login") {
    return { name: "Login" };
  }
}

export default router;
