using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diarna.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using Diarna.DTOs.Building2;
using System.Collections.Generic;
using Diarna.Data.Domain;
using System;


namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Building2Controller : ControllerBase
    {
        private readonly IBuilding2 _building;
        private readonly IMapper _mapper;
        public Building2Controller(IBuilding2 building, IMapper mapper)
        {
            this._mapper = mapper;
            this._building = building;
        }

        [HttpGet(Name = "GetAllBuildings2")]
        public async Task<IActionResult> GetAllBuildings2()
        {
            var result = await _building.GetAllBuildings2();
            var mapper = _mapper.Map<IEnumerable<ReadBuilding2Dto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{id}", Name = "GetBuildingsById2")]
        public async Task<IActionResult> GetBuildingsById2(int id)
        {
            var result = await _building.GetBuildingsById2(id);
            if (result == null)
                return StatusCode(500, "No Such id");
            //return NotFound();
            var mapper = _mapper.Map<ReadBuilding2Dto>(result);
            return Ok(mapper);
        }

        [HttpGet("{name}", Name = "GetBuildingsByName2")]
        public async Task<IActionResult> GetBuildingsByName2(string name)
        {
            var result = await _building.GetBuildingsByName2(name);
            if (result == null)
                return StatusCode(500, "No Such id");
            //return NotFound();
            var mapper = _mapper.Map<ReadBuilding2Dto>(result);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddBuilding2([FromBody] CreateBuilding2Dto dto)
        {
            var mapper = _mapper.Map<TblBuilding>(dto);
            var result = await _building.AddBuilding2(mapper);
            if (result == null)
                return StatusCode(500, "No thing Added");
            return CreatedAtRoute(nameof(GetBuildingsById2), new { Id = result.Id }, result);
            //return Ok("Added Successfully");
        }

        [HttpPut("{id}", Name = "UpdateBuilding2")]
        public async Task<IActionResult> UpdateBuilding2(int id, [FromBody] CreateBuilding2Dto dto)
        {
            var returned = await _building.GetBuildingsById2(id);
            _mapper.Map(dto, returned);
            var result = await _building.UpdateBuilding2(returned);
            var mapper = _mapper.Map<ReadBuilding2Dto>(result);
            if (mapper == null)
                return StatusCode(500, "No thing Updated");
            return Ok("Edited Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuilding2(int id)
        {
            var result = await _building.DeleteBuilding2(id);
            if (result)
                return Ok("Deleted Successfully");
            return StatusCode(500, "No thing Deleted");
        }



    }
}
