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
    public class RegionController : TestJobBaseController
    {    
        private readonly IRegionManager _regionManager;
        private readonly IMapper _mapper;

        public RegionController(IRegionManager regionManager, IMapper mapper)
        {
            _regionManager = regionManager;
            _mapper = mapper;
        }     
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var cities = await _regionManager.GetItem(id);
            return Ok(cities);
        }
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {         
            var result = await _regionManager.GetItems();
            var resultDto = (_mapper.Map<IEnumerable<RegionDto>>(result));
            return Ok(resultDto);
        }
        [HttpPost("AddRegion")]
        public async Task<IActionResult> AddToCollection([FromBody] RegionDto region)
        {
            var id = await _regionManager.Create(_mapper.Map<Region>(region));
            return Ok(id);
        }       
        [HttpPut("UpdateRegion/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] RegionDto region)
        {
            await _regionManager.Update(id, _mapper.Map<Region>(region));
            return Ok();
        }    
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _regionManager.Delete(id);
            return Ok();
        }   
    }  
}
 