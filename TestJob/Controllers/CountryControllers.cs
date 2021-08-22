using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestJob.Domain.Interfaces;
using TestJob.Models.Dto;
using TestJob.Models;
using AutoMapper;

namespace TestJob.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class CountryController : TestJobBaseController
    {
        private readonly ICountryManager _countryManager;
        private readonly IMapper _mapper;

        public CountryController(ICountryManager countryManager, IMapper mapper)
        {
            _countryManager = countryManager;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _countryManager.GetItems();
            var resultDto = (_mapper.Map<IEnumerable<CountryDto>>(result));
            return Ok(resultDto);
        }
        /// <summary>
        /// Добавить страну
        /// </summary>
        /// <returns>Id добавленной страны</returns>
        [HttpPost("AddCountry")]
        public async Task<IActionResult> AddToCollection([FromBody] CountryDto cities)
        {
            var id = await _countryManager.Create(_mapper.Map<Country>(cities));
            return Ok(id);
        }
        [HttpPut("UpdateCities/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CountryDto cities)
        {
            await _countryManager.Update(id, _mapper.Map<Country>(cities));
            return Ok();
        }
    }  
}

