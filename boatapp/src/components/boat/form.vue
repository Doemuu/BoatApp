<template>
  <div class="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
    <form class="space-y-6">
      <div>
        <label
          for="name"
          class="block text-sm font-medium leading-6 text-indigo-600 text-left"
          >Name</label
        >
        <div class="mt-2">
          <input
            id="name"
            v-model="boat.name"
            name="username"
            type="text"
            required
            class="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
          />
        </div>
      </div>

      <div>
        <label
          for="description"
          class="block text-sm font-medium leading-6 text-indigo-600 text-left"
          >Description</label
        >
        <div class="mt-2">
          <textarea
            id="description"
            v-model="boat.description"
            name="description"
            type="text"
            required
            class="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
          ></textarea>
        </div>
      </div>
      <div>
        <label
          for="colour"
          class="block text-sm font-medium leading-6 text-indigo-600 text-left"
          >Colour</label
        >
        <div class="mt-2">
          <select
            id="countries"
            v-model="boat.colour"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          >
            <option
              v-for="colour in colours"
              :key="colour"
              :value="colours.indexOf(colour)"
            >
              {{ colour }}
            </option>
          </select>
        </div>
      </div>
      <div>
        <div
          :class="[caller.type === 'update' ? 'grid grid-cols-2 gap-4' : '']"
        >
          <button
            type="button"
            @click="handleSubmission"
            :class="{ 'w-full': caller.type !== 'update' }"
            class="flex justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
          >
            Save
          </button>
          <button
            type="button"
            @click="askDeleteConfirmation"
            v-if="caller.type === 'update'"
            class="flex justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
          >
            Delete
          </button>
        </div>
      </div>
    </form>
    <div class="" v-if="isDeleteConfirmation">
      <p>Are you sure you want to delete the boat?</p>
      <div class="grid grid-cols-2 gap-4">
        <button
          type="button"
          @click="handleDelete"
          class="flex justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
        >
          Continue
        </button>
        <button
          type="button"
          @click="askDeleteConfirmation"
          class="flex justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
        >
          Cancel
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import colours from "../../assets/colours";
export default {
  name: "BoatForm",
  props: {
    propBoat: Object,
  },
  data() {
    return {
      boat: this.propBoat,
      colours: colours,
      caller: this.checkCaller(),
      isDeleteConfirmation: false,
    };
  },
  methods: {
    checkCaller() {
      if (this.$route.params.id !== undefined) {
        return { type: "update" };
      }
      return { type: "submission" };
    },
    async handleSubmission() {
      this.$emit("submission", { boat: this.boat });
    },
    askDeleteConfirmation() {
      this.isDeleteConfirmation = !this.isDeleteConfirmation;
    },
    async handleDelete() {
      this.$emit("delete", { boat: this.boat });
    },
  },
};
</script>

<style>
</style>
