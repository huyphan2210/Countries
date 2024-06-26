﻿using Countries.Server.Models;
using Countries.Server.Models.DTOs;
using Countries.Server.Repositories;

namespace Countries.Server.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<GetCountriesResponse> GetCountries(GetCountriesRequest getCountriesRequest)
        {
            return await _countryRepository.GetCountries(getCountriesRequest);
        }

        public async Task<Country> GetCountry(string countryName)
        {
            return await _countryRepository.GetCountry(countryName);
        }
    }
}
