<template>
  <Layout>
    <div class="m-4">
      <div class="grid grid-cols-4">
        <div class="text-right col-span-4 col-start-4">
          <button
            @click="addNewBoat"
            type="button"
            class="rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
          >
            Add
          </button>
        </div>
      </div>
    </div>
    <div class="bg-gray-100 m-2 text-gray-600 mx-4 break-words">
      <div class="grid grid-cols-8 border font-semibold">
        <div class="col-span-3 p-1">Id</div>
        <div class="col-span-1 p-1 bg-gray-200">Name</div>
        <div class="col-span-3 p-1">Description</div>
        <div class="col-span-1 p-1 bg-gray-200">Colour</div>
      </div>
      <div
        class="grid grid-cols-8 border-x border-b cursor-pointer"
        v-for="boat in boats"
        :key="boat.id"
        v-on:click="handleClick(boat.id)"
      >
        <div class="col-span-3 p-1">{{ boat.id }}</div>
        <div class="col-span-1 p-1 bg-gray-200">{{ boat.name }}</div>
        <div class="col-span-3 p-1">{{ boat.description }}</div>
        <div
          class="col-span-1 p-1 bg-gray-200"
          :style="{ 'background-color': colours[boat.colour] }"
        ></div>
      </div>
    </div>
  </Layout>
</template>

<script>
import Layout from "../components/layout/layout.vue";
import axios from "axios";
import colours from "../assets/colours";
export default {
  components: { Layout },
  data() {
    return {
      boats: [],
      colours: colours,
    };
  },
  beforeMount() {
    this.fetchBoats();
  },
  methods: {
    async fetchBoats() {
      const options = {
        method: "GET",
        url: "http://localhost:5000/api/boat/all",
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
      };
      try {
        const response = await axios.request(options);
        if (response.status === 200 && response.data !== undefined) {
          this.boats = response.data;
        } else if (response.status === 401) {
          this.$router.push({ name: "Login" });
        }
      } catch (error) {
        console.log(error);
      }
    },
    handleClick(event) {
      console.log(event);
    },
  },
};
</script>

<style>
</style>
