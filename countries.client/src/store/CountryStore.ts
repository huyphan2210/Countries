import { createStore } from "vuex";
import { type Country } from "@/swagger/api";
import CountryAPI from "@/api/country-api";

const countryAPI = new CountryAPI();

export const MUTATION_TYPES = {
  setCountries: "setCountries",
};

export const ACTION_TYPES = {
  getCountries: "getCountries",
};

interface CountryState {
  countries: Country[];
}

export const store = createStore<CountryState>({
  state: {
    countries: [],
  },
  mutations: {
    setCountries(state: CountryState, countries: Country[]) {
      state.countries = [...countries];
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
