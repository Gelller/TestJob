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
    public class CitiesController : TestJobBaseController
    {
        private readonly ICitiesManager _citiesManager;
        private readonly IMapper _mapper;
        public CitiesController(ICitiesManager citiesManager, IMapper mapper)
        {
            _citiesManager = citiesManager;
            _mapper = mapper;
        }    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var cities = await _citiesManager.GetItem(id);
            return Ok(cities);
        }
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _citiesManager.GetItems();
            var resultDto = (_mapper.Map<IEnumerable<CitiesDto>>(result));
            return Ok(resultDto);
        }
        [HttpPost("AddCities")]
        public async Task<IActionResult> AddToCollection([FromBody] CitiesDto cities)
        {
            var id = await _citiesManager.Create(_mapper.Map<Cities>(cities));
            return Ok(id);
        }
        [HttpPut("UpdateCities/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CitiesDto cities)
        {
            await _citiesManager.Update(id, _mapper.Map<Cities>(cities));
            return Ok();
        }     
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _citiesManager.Delete(id);
            return Ok();
        }      
    }
}
