<template>
  <div>
    <div v-if="boat.id === undefined">
      <p>Loading...</p>
    </div>
    <div v-else>
      <BoatForm
        @submission="handleSubmission"
        @delete="handleDelete"
        :propBoat="boat"
      />
      <div class="grid grid-cols-1">
        <p class="mx-auto text-red-600">{{ errorMessage }}</p>
      </div>
    </div>
  </div>
</template>

<script>
import BoatForm from "../../components/boat/form.vue";
import axios from "axios";
export default {
  components: {
    BoatForm,
  },
  data() {
    return {
      boat: {},
      errorMessage: "",
    };
  },
  beforeMount() {
    this.checkBoat();
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
    checkBoat() {
      if (this.$store.state.activeBoat !== undefined) {
        this.boat = this.$store.state.activeBoat;
      } else {
        this.fetchBoat();
      }
    },
    async fetchBoat() {
      const options = {
        method: "GET",
        url: `http://localhost:5000/api/boat/${this.$route.params.id}`,
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
      };
      try {
        const response = await axios.request(options);
        if (response.status === 200 && response.data !== undefined) {
          this.boat = response.data;
          this.$store.dispatch("updateBoat", response.data);
        }
      } catch (error) {
        if (error.response.status === 401) {
          this.$router.push({ name: "Login" });
        }
        console.log(error);
      }
    },
    async handleSubmission({ boat }) {
      if (this.validation(boat)) {
        const params = {
          id: boat.id,
          name: boat.name,
          description: boat.description,
          colour: boat.colour,
        };

        const options = {
          method: "PATCH",
          url: `http://localhost:5000/api/boat/update`,
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
    async handleDelete({ boat }) {
      const options = {
        method: "DELETE",
        url: `http://localhost:5000/api/boat/delete/${boat.id}`,
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
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
    },
  },
};
</script>

<style>
</style>
