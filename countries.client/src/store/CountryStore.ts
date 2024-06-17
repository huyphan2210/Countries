import { createStore } from "vuex";
import { type GetCountriesResponse as FrontPageCountries } from "@/swagger/api";
import CountryAPI from "@/api/country-api";

const countryAPI = new CountryAPI();

export const MUTATION_TYPES = {
  setCountries: "setCountries",
  setIsDarkMode: "setIsDarkMode",
  setCurrentRegion: "setCurrentRegion",
  setPagination: "setPagination",
};

export const ACTION_TYPES = {
  getCountries: "getCountries",
};

export interface CountryState {
  currentRegion: string;
  countries: FrontPageCountries[];
  isDarkMode: boolean;
  isFetchingData: boolean;
  currentPage: number;
  pageSize: number;
}

export const store = createStore<CountryState>({
  state: {
    currentRegion: "",
    countries: [],
    isDarkMode: localStorage.getItem("isDarkMode") ? true : false,
    isFetchingData: false,
    currentPage: 1,
    pageSize: 20,
  },
  mutations: {
    setCountries(state: CountryState, countries: FrontPageCountries[]) {
      state.countries = [...state.countries, ...countries];
    },
    setIsDarkMode(state: CountryState) {
      state.isDarkMode = !state.isDarkMode;
      if (state.isDarkMode) {
        localStorage.setItem("isDarkMode", "true");
        document.documentElement.classList.add("dark-mode");
      } else {
        localStorage.removeItem("isDarkMode");
        document.documentElement.classList.remove("dark-mode");
      }
    },
    setCurrentRegion(state: CountryState, region: string) {
      state.currentRegion = region;
    },
    setPagination(state: CountryState) {
      state.currentPage += 1;
    },
  },
  actions: {
    async getCountries({ commit }): Promise<void> {
      try {
        this.state.isFetchingData = true;
        const countries = await countryAPI.getCountries(
          this.state.currentPage,
          this.state.pageSize
        );
        commit(MUTATION_TYPES.setCountries, countries);
      } catch (error) {
        throw new Error();
      } finally {
        this.state.isFetchingData = false;
      }
    },
  },
});
