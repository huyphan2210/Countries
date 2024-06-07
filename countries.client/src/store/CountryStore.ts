import { createStore } from "vuex";
import { type Country } from "@/swagger/api";
import CountryAPI from "@/api/country-api";

const countryAPI = new CountryAPI();

export const MUTATION_TYPES = {
  setCountries: "setCountries",
  setIsDarkMode: "setIsDarkMode",
};

export const ACTION_TYPES = {
  getCountries: "getCountries",
};

export interface CountryState {
  countries: Country[];
  isDarkMode: boolean;
}

export const store = createStore<CountryState>({
  state: {
    countries: [],
    isDarkMode: false,
  },
  mutations: {
    setCountries(state: CountryState, countries: Country[]) {
      state.countries = [...countries];
    },
    setIsDarkMode(state: CountryState) {
      state.isDarkMode = !state.isDarkMode;
      if (state.isDarkMode) {
        document.documentElement.classList.add('dark-mode');
      } else {
        document.documentElement.classList.remove('dark-mode');
      }
    },
  },
  actions: {
    async getCountries({ commit }): Promise<void> {
      try {
        const countries = await countryAPI.getCountries();
        commit(MUTATION_TYPES.setCountries, countries);
      } catch (error) {
        throw new Error();
      }
    },
  },
});
