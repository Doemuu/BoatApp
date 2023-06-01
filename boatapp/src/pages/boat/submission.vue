<template>
  <div>
    <BoatForm @submission="dispatchNewBoat" :propBoat="{}"> </BoatForm>
    <div class="grid grid-cols-1">
      <p class="mx-auto text-red-600">{{ errorMessage }}</p>
    </div>
  </div>
</template>

<script>
import BoatForm from "../../components/boat/form.vue";
import axios from "axios";
export default {
  data() {
    return {
      errorMessage: "",
    };
  },
  components: {
    BoatForm,
  },
  methods: {
    validation(boat) {
      if (
        boat.name === "" ||
        boat.name === undefined ||
        boat.description === "" ||
        boat.description === undefined
      ) {
        this.errorMessage = "Inputs are required";
        return false;
      }
      return true;
    },
    async dispatchNewBoat({ boat }) {
      if (this.validation(boat)) {
        const params = {
          name: boat.name,
          description: boat.description,
          colour: boat.colour,
        };
        const options = {
          method: "POST",
          url: `http://localhost:5000/api/boat/add`,
          headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
          data: params,
        };
        try {
          const response = await axios.request(options);
          if (response.status === 200 && response.data !== undefined) {
            this.$router.push({ name: "home" });
          }
        } catch (error) {
          if (error.response.status === 401) {
            this.$router.push({ name: "Login" });
          }
          console.log(error);
        }
      }
    },
  },
};
</script>

<style>
</style>
