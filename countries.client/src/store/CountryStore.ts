import { createStore } from "vuex";
import { type Country, type CountryBriefInfo } from "@/swagger/api";
import CountryAPI from "@/api/country-api";

const countryAPI = new CountryAPI();

export const MUTATION_TYPES = {
  setCountries: "setCountries",
  setIsDarkMode: "setIsDarkMode",
  setCurrentRegion: "setCurrentRegion",
  setPagination: "setPagination",
  setSearchString: "setSearchString",
  setTotalCountries: "setTotalCountries",
  setCurrentCountry: "setCurrentCountry",
};

export const ACTION_TYPES = {
  getCountries: "getCountries",
  getCountry: "getCountry",
};

export interface CountryState {
  currentRegion: string;
  currentCountry?: Country;
  totalCountries: number;
  countries: CountryBriefInfo[];
  isDarkMode: boolean;
  isFetchingData: boolean;
  currentPage: number;
  pageSize: number;
  searchString?: string;
}

export const store = createStore<CountryState>({
  state: {
    currentRegion: "",
    totalCountries: 0,
    countries: [],
    isDarkMode: localStorage.getItem("isDarkMode") ? true : false,
    isFetchingData: false,
    currentPage: 1,
    pageSize: 12,
    searchString: undefined,
  },
  mutations: {
    setCountries(state: CountryState, countries: CountryBriefInfo[]) {
      if (state.currentPage > 1) {
        state.countries = [...state.countries, ...countries];
      } else {
        state.countries = [...countries];
      }
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
      state.currentPage = 1;
      state.currentRegion = region;
    },
    setPagination(state: CountryState) {
      state.currentPage += 1;
    },
    setSearchString(state: CountryState, searchString: string) {
      state.currentPage = 1;
      state.searchString = searchString;
    },
    setTotalCountries(state: CountryState, count: number) {
      state.totalCountries = count;
    },
    setCurrentCountry(state: CountryState, country?: Country) {
      state.currentCountry = country;
      if (state.currentCountry) {
        document.getElementsByTagName("body")[0].className = "no-scroll";
      } else {
        document.getElementsByTagName("body")[0].className = "";
      }
    },
  },
  actions: {
    async getCountries({ commit }): Promise<void> {
      try {
        this.state.isFetchingData = true;
        const { totalCountries, countries } = await countryAPI.getCountries(
          this.state.currentPage,
          this.state.pageSize,
          this.state.searchString,
          this.state.currentRegion
        );
        commit(MUTATION_TYPES.setCountries, countries);
        commit(MUTATION_TYPES.setTotalCountries, totalCountries);
      } catch (error) {
        throw new Error();
      } finally {
        this.state.isFetchingData = false;
      }
    },
    async getCountry({ commit }, countryName: string): Promise<void> {
      try {
        this.state.isFetchingData = true;
        const country = await countryAPI.getCountry(countryName);
        commit(MUTATION_TYPES.setCurrentCountry, country);
      } catch (error) {
        throw new Error();
      } finally {
        this.state.isFetchingData = false;
      }
    },
  },
});
