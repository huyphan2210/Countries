<script setup lang="ts">
import { Store, useStore } from "vuex";
import { ref, onMounted, onUnmounted } from "vue";
import { debounce } from "lodash";
import {
  ACTION_TYPES,
  MUTATION_TYPES,
  type CountryState,
} from "./store/CountryStore";
import CountryCard from "./components/CountryCard.vue";
import LoadingScreen from "./components/LoadingScreen.vue";
import moonLight from "./assets/moon-light.svg";
import moonDark from "./assets/moon-dark.svg";
import searchLight from "./assets/search-light.svg";
import searchDark from "./assets/search-dark.svg";
import chevron from "./assets/chevron.svg";

const { state, dispatch, commit }: Store<CountryState> = useStore();
dispatch(ACTION_TYPES.getCountries);

if (state.isDarkMode) {
  document.documentElement.classList.add("dark-mode");
}
const regions: string[] = ["Africa", "America", "Asia", "Europe", "Oceania"];

const isFilterOpened = ref(false);

const handleScroll = debounce(() => {
  const scrollTop = window.scrollY || document.documentElement.scrollTop;
  const scrollHeight = document.documentElement.scrollHeight;
  const clientHeight = document.documentElement.clientHeight;

  if (
    scrollTop + clientHeight >= scrollHeight - 5 &&
    state.countries.length < state.totalCountries
  ) {
    commit(MUTATION_TYPES.setPagination);
    dispatch(ACTION_TYPES.getCountries);
  }
}, 200);

const setSearchString = (value: string) => {
  commit("setSearchString", value);
  dispatch("getCountries");
};
const debouncedSetSearchString = debounce(setSearchString, 300);

onMounted(() => {
  window.addEventListener("scroll", handleScroll);
});

onUnmounted(() => {
  window.removeEventListener("scroll", handleScroll);
});
</script>

<template>
  <header>
    <h1>Where in the world?</h1>
    <button
      class="dark-mode-button"
      type="button"
      @click="() => commit(MUTATION_TYPES.setIsDarkMode)"
    >
      <img
        v-if="!state.isDarkMode"
        :src="moonLight"
        loading="lazy"
        alt="Moon Light"
      />
      <img v-else :src="moonDark" loading="lazy" alt="Moon Dark" />
      <span>Dark mode</span>
    </button>
  </header>
  <main>
    <loading-screen v-if="state.isFetchingData" />
    <section class="filter-section">
      <div class="filter-section__search-wrapper">
        <img
          v-if="!state.isDarkMode"
          :src="searchLight"
          loading="lazy"
          alt="Search Light"
        />
        <img v-else :src="searchDark" loading="lazy" alt="Search Dark" />
        <input
          @input="(e) => {
            const inputValue = (e.currentTarget as HTMLInputElement).value;
            debouncedSetSearchString(inputValue);
          }"
          placeholder="Search for a country..."
          type="text"
        />
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
          state.currentRegion ? state.currentRegion : "Filter by Region"
        }}</span>
        <img :src="chevron" loading="lazy" alt="Chevron" />
        <ul class="filter-section__options__region">
          <li v-for="(region, index) in regions" :key="index">
            <button
              type="button"
              @click="
                () => {
                  commit(MUTATION_TYPES.setCurrentRegion, region);
                  dispatch(ACTION_TYPES.getCountries);
                }
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
        v-for="(country, index) in state.countries"
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
  z-index: 1;
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
    gap: 1.5rem;
  }
}

@media screen and (min-width: 768px) {
  main {
    .countries-section {
      grid-template-columns: repeat(2, calc((100% - 3rem) / 2));
      gap: 3rem;
    }
  }
}

@media screen and (min-width: 1024px) {
  main {
    .countries-section {
      grid-template-columns: repeat(3, calc((100% - 12rem) / 3));
      gap: 6rem;
    }
  }
}

@media screen and (min-width: 1440px) {
  main {
    .countries-section {
      grid-template-columns: repeat(4, calc((100% - 18rem) / 4));
    }
  }
}
</style>
