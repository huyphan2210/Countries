<script setup lang="ts">
import { Store, useStore } from "vuex";
import { computed } from "vue";
import { ACTION_TYPES, MUTATION_TYPES, type CountryState } from "./store/CountryStore";
import moonLight from "./assets/moon-light.svg";
import moonDark from "./assets/moon-dark.svg";

const store: Store<CountryState> = useStore();
store.dispatch(ACTION_TYPES.getCountries);

const isDarkMode = computed(() => store.state.isDarkMode)

</script>

<template>
  <header>
    <h1>Where in the world?</h1>
    <button
      class="dark-mode-button"
      type="button"
      @click="() => store.commit(MUTATION_TYPES.setIsDarkMode)"
    >
      <img v-if="!isDarkMode" :src="moonLight" loading="lazy" alt="Moon Light" />
      <img v-else :src="moonDark" loading="lazy" alt="Moon Dark" />
      <span>Dark mode</span>
    </button>
  </header>
  <main></main>
  <footer></footer>
</template>

<style scoped>
header,
main,
footer {
  padding: 1.5rem;
}

header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  h1 {
    font-size: 1rem;
  }
  .dark-mode-button {
    border: none;
    background-color: transparent;
    display: flex;
    align-items: center;
    gap: 1rem;

    img {
      width: 1rem;
    }

    span {
      font-weight: 500;
    }
  }
}
</style>
