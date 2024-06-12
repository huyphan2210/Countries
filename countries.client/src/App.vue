<script setup lang="ts">
import { Store, useStore } from "vuex";
import { computed, ref } from "vue";
import {
  ACTION_TYPES,
  MUTATION_TYPES,
  type CountryState,
} from "./store/CountryStore";
import CountryCard from "./components/CountryCard.vue";
import moonLight from "./assets/moon-light.svg";
import moonDark from "./assets/moon-dark.svg";
import searchLight from "./assets/search-light.svg";
import searchDark from "./assets/search-dark.svg";
import chevron from "./assets/chevron.svg";

const store: Store<CountryState> = useStore();
store.dispatch(ACTION_TYPES.getCountries);

const isDarkMode = computed(() => store.state.isDarkMode);
const regions: string[] = ["Africa", "America", "Asia", "Europe", "Oceania"];

const isFilterOpened = ref(false);
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
      <button
        type="button"
        class="filter-section__options"
        :class="isFilterOpened ? 'opened' : ''"
        @click="
          () => {
            isFilterOpened = !isFilterOpened;
          }
        "
      >
        <span>{{
          store.state.currentRegion
            ? store.state.currentRegion
            : "Filter by Region"
        }}</span>
        <img :src="chevron" loading="lazy" alt="Chevron" />
        <ul class="filter-section__options__region">
          <li v-for="(region, index) in regions" :key="index">
            <button
              type="button"
              @click="
                () => store.commit(MUTATION_TYPES.setCurrentRegion, region)
              "
            >
              {{ region }}
            </button>
          </li>
        </ul>
      </button>
    </section>
    <section class="countries-section">
      <country-card
        v-for="(country, index) in store.state.countries"
        :key="index"
        :country="country"
      ></country-card>
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
    margin-bottom: 1.5rem;
    &__search-wrapper {
      border-radius: var(--border-radius);
      background-color: var(--element-bg);
      padding: 1rem 1.5rem;
      display: flex;
      gap: 1rem;
      width: 100%;
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
      position: relative;
      border: none;
      background-color: var(--element-bg);
      padding: 1rem 1.5rem;
      border-radius: var(--border-radius);
      display: flex;
      gap: 1rem;
      align-items: center;
      justify-content: space-between;
      min-width: 10rem;

      img {
        width: 1rem;
      }

      &__region {
        position: absolute;
        top: 0;
        width: calc(100% - 3rem);
        left: 0;
        background-color: var(--element-bg);
        padding: 1rem 1.5rem;
        border-radius: var(--border-radius);
        margin: 0;
        list-style: none;
        display: grid;
        gap: 1rem;
        z-index: -1;
        opacity: 0;

        li {
          text-align: left;
          button {
            border: none;
            background-color: transparent;
          }
        }
      }

      &.opened {
        img {
          transform: rotate(180deg);
        }

        .filter-section__options__region {
          top: calc(100% + 1rem);
          z-index: 0;
          opacity: 1;
        }
      }
    }
  }

  .countries-section {
    display: grid;
    gap: 1rem;
  }
}

@media screen and (min-width: 768px) {
  main {
    .countries-section {
      grid-template-columns: repeat(2, auto);
    }
  }
}
</style>
