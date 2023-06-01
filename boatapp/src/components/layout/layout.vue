<template>
  <div>
    <div>
      <nav class="bg-transparent">
        <div
          class="max-w-screen-xl flex flex-row-reverse mx-auto p-4 bg-indigo-600"
        >
          <div
            @click="toggleDropdown"
            class="relative inline-flex items-center justify-center w-10 h-10 overflow-hidden bg-gray-100 rounded-full dark:bg-gray-600 cursor-pointer"
          >
            <span class="font-medium text-gray-600 dark:text-gray-300">{{
              initials
            }}</span>
          </div>
        </div>
        <div
          id="dropdown"
          v-if="dropdownToggled"
          class="z-10 bg-white absolute divide-y divide-gray-100 rounded-lg shadow w-44 dark:bg-gray-700 float-right mr-2 end-0"
        >
          <ul
            class="py-2 text-sm text-gray-700 dark:text-gray-200"
            aria-labelledby="dropdownDefaultButton"
          >
            <li>
              <a
                @click="signout"
                class="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white"
                >Sign out</a
              >
            </li>
          </ul>
        </div>
      </nav>
    </div>
    <slot></slot>
    <div></div>
  </div>
</template>

<script>
export default {
  name: "Layout",
  data() {
    return {
      initials: "",
      dropdownToggled: false
    };
  },
  created() {
    this.getInitials();
  },
  methods: {
    getInitials() {
      let username = localStorage.getItem("username");
      if (username !== null) {
        this.initials = username.substring(0, 2).toUpperCase();
      }
    },
    toggleDropdown(){
      this.dropdownToggled = !this.dropdownToggled;
    },
    signout(){
      localStorage.removeItem("username");
      localStorage.removeItem("token");
      this.$router.push({name: "Login"})
    }
  },
};
</script>

<style lang="scss">
.profile {
}
</style>
