import { createStore } from "vuex";

const store = createStore({
  state() {
    return {
      user: undefined,
    };
  },
  mutations: {
    updateUser(state, payload) {
      state.user = payload.user;
    },
  },
  actions: {
    updateUser(context, payload) {
      if (payload.user !== undefined) {
        context.commit("updateUser", payload);
      }
    },
  },
});

export default store;
