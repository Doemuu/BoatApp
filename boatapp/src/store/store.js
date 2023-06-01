import { createStore } from "vuex";

const store = createStore({
  state() {
    return {
      activeBoat: undefined,
    };
  },
  mutations: {
    updateBoat(state, payload) {
      state.activeBoat = payload;
    },
  },
  actions: {
    updateBoat(context, payload) {
      if (payload !== undefined) {
        context.commit("updateBoat", payload);
      }
    },
  },
});

export default store;
