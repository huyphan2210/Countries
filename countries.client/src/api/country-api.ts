import axios, { type AxiosInstance } from "axios";
import { CountryService, serviceOptions } from "../swagger/api";

export default class CountryAPI {
  axiosInstance: AxiosInstance = axios.create({
    baseURL: import.meta.env.PROD ? "" : "",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
  });

  constructor() {
    serviceOptions.axios = this.axiosInstance;
  }

  getCountries(
    page: number,
    pageSize: number,
    searchString?: string,
    region?: string
  ) {
    return CountryService.getCountries({
      page,
      pageSize,
      searchString,
      region,
    });
  }

  getCountry(countryName: string) {
    return CountryService.getCountry({ countryName });
  }
}
