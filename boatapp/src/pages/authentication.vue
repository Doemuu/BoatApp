<template>
  <div
    class="flex min-h-full flex-1 flex-col justify-center px-6 py-12 lg:px-8"
  >
    <div class="sm:mx-auto sm:w-full sm:max-w-sm">
      <h2
        class="mt-10 text-center text-2xl font-bold leading-9 tracking-tight text-white-900"
      >
        Sign in to your account
      </h2>
    </div>

    <div class="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
      <form class="space-y-6">
        <div>
          <label
            for="username"
            class="block text-sm font-medium leading-6 text-indigo-600 text-left"
            >Username</label
          >
          <div class="mt-2">
            <input
              id="username"
              v-model="username"
              name="username"
              type="text"
              required
              class="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
            />
          </div>
        </div>

        <div>
          <label
            for="password"
            class="block text-sm font-medium leading-6 text-indigo-600 text-left"
            >Password</label
          >
          <div class="mt-2">
            <input
              id="password"
              v-model="password"
              name="password"
              type="password"
              required
              class="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
            />
          </div>
        </div>
        <div>
          <button
            type="button"
            @click="handleSubmission"
            class="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
          >
            Sign in
          </button>
        </div>

        <div class="errorMessage" v-if="errorMessage !== ''">
          <p class="text-danger">{{ errorMessage }}</p>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      username: "",
      password: "",
      errorMessage: "",
    };
  },
  methods: {
    async handleSubmission() {
      const params = {
        username: this.username,
        password: this.password,
      };

      const options = {
        method: "POST",
        url: "http://localhost:5000/api/authentication/Login",
        data: params,
      };

      try {
        const response = await axios.request(options);
        if (response.status === 200 && response.data !== undefined) {
          localStorage.setItem("username", this.username);
          localStorage.setItem("token", response.data.token );
          this.$router.push({ name: "home" });
        }
      } catch (error) {
        this.errorMessage = error;
      }
    },
  },
};
</script>

<style lang="scss">
</style>
