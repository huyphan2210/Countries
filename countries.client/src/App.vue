<script setup lang="ts">
import { Store, useStore } from "vuex";
import { computed } from "vue";
import {
  ACTION_TYPES,
  MUTATION_TYPES,
  type CountryState,
} from "./store/CountryStore";

import moonLight from "./assets/moon-light.svg";
import moonDark from "./assets/moon-dark.svg";
import searchLight from "./assets/search-light.svg";
import searchDark from "./assets/search-dark.svg";

const store: Store<CountryState> = useStore();
store.dispatch(ACTION_TYPES.getCountries);

const isDarkMode = computed(() => store.state.isDarkMode);
</script>

<template>
  <header>
    <h1>Where in the world?</h1>
    <button
      class="dark-mode-button"
      type="button"
      @click="() => store.commit(MUTATION_TYPES.setIsDarkMode)"
    >
      <img
        v-if="!isDarkMode"
        :src="moonLight"
        loading="lazy"
        alt="Moon Light"
      />
      <img v-else :src="moonDark" loading="lazy" alt="Moon Dark" />
      <span>Dark mode</span>
    </button>
  </header>
  <main>
    <section class="filter-section">
      <div class="filter-section__search-wrapper">
        <img
          v-if="!isDarkMode"
          :src="searchLight"
          loading="lazy"
          alt="Search Light"
        />
        <img v-else :src="searchDark" loading="lazy" alt="Search Dark" />
        <input placeholder="Search for a country..." type="text" />
      </div>
      <div class="filter-section__options">
        <select title="Filter by Region" value="">
          <option value="" hidden>Filter by Region</option>
          <option value="Asia">Asia</option>
          <option value="Europe">Europe</option>
        </select>
      </div>
    </section>
  </main>
  <footer></footer>
</template>

<style lang="scss" scoped>
header,
main,
footer {
  padding: 1.5rem;
}

header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background-color: var(--element-bg);
  position: sticky;
  top: 0;
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

main {
  background-color: var(--main-bg);
  .filter-section {
    display: flex;
    justify-content: space-between;
    align-items: center;
    gap: 1.5rem;
    flex-wrap: wrap;
    &__search-wrapper {
      border-radius: var(--border-radius);
      background-color: var(--element-bg);
      padding: 1rem 1.5rem;
      display: flex;
      gap: 1rem;
      max-width: 30rem;

      img {
        width: 1rem;
      }

      input {
        flex-grow: 1;
        border: none;
        background-color: transparent;
        &:focus {
          outline: none;
        }

        &::placeholder {
          color: var(--text-color);
        }
      }
    }

    &__options {
      select {
        background-color: transparent;
        padding: 1rem 1.5rem;
        option {
          background-color: var(--element-bg);
        }
      }
    }
  }
}
</style>
