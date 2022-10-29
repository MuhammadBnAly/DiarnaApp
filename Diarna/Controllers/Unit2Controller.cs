using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diarna.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using Diarna.DTOs.Unit2;
using System.Collections.Generic;
using Diarna.Data.Domain;
using System;

namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Unit2Controller : ControllerBase
    {
        private readonly IUnit2 _unit;
        private readonly IMapper _mapper;
        private readonly IUpdateUnit2 _updateUnit;
        public Unit2Controller(IUnit2 unit, IMapper mapper, IUpdateUnit2 updateUnit)
        {
            this._unit = unit;
            this._mapper = mapper;
            this._updateUnit = updateUnit;
        }

        [HttpGet(Name = "GetAllUnits2")]
        public async Task<IActionResult> GetAllUnits2()
        {
            var result = await _unit.GetAllUnits2();
            var mapper = _mapper.Map<IEnumerable<ReadUnit2Dto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{id}", Name = "GetUnitById2")]
        public async Task<IActionResult> GetUnitById2(int id)
        {
            var result = await _unit.GetUnitById2(id);
            if (result == null)
                return StatusCode(500, "No Such id");
            //return NotFound();
            var mapper = _mapper.Map<ReadUnit2Dto>(result);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddUnit2([FromBody] CreateUnit2Dto dto)
        {
            var mapper = _mapper.Map<TblUnit>(dto);
            var result = await _unit.AddUnit2(mapper);
            if (result == null)
                return StatusCode(500, "No thing Added");
            return CreatedAtRoute(nameof(GetUnitById2), new { Id = result.Id }, result);
            //return Ok("Added Successfully");
        }

        [HttpPut("{id}", Name = "UpdateUnit2")]
        public async Task<IActionResult> UpdateUnit2(int id, [FromBody] CreateUnit2Dto dto)
        {
            var returned = await _unit.GetUnitById2(id);
            _mapper.Map(dto, returned);
            var result = await _unit.UpdateUnit2(returned);
            var mapper = _mapper.Map<ReadUnit2Dto>(result);
            if (mapper == null)
                return StatusCode(500, "No thing Updated");
            return Ok("Edited Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnit2(int id)
        {
            var result = await _unit.DeleteUnit2(id);
            if (result == null)
                return StatusCode(500, "No thing Deleted");
            return Ok("Deleted Successfully");
        }


        //
        [HttpGet("{id}", Name = "getUpdateUnit2")]
        public async Task<IActionResult> getUpdateUnitById2(int id)
        {
            var result = await _updateUnit.getUpdateUnitById2(id);
            var mapper = _mapper.Map<ReadUpdateUnit2Dto>(result);
            if (result == null)
                return NotFound();
            return Ok(mapper);
        }

        [HttpPut("{id}", Name = "EditUpdateUnit2")]
        public async Task<IActionResult> EditUpdateUnit2(int id, [FromBody] EditUpdateUnit2Dto dto)
        {
            var returned = await _updateUnit.getUpdateUnitById2(id);
            _mapper.Map(dto, returned);
            var result = await _updateUnit.EditUpdateUnit2(returned);
            var mapper = _mapper.Map<ReadUpdateUnit2Dto>(result);
            if (mapper == null)
                return NotFound();
            //return CreatedAtRoute(nameof(getUpdateUnitById2), new { id = result.Id }, mapper);
            return Ok("Successfully Edited");
        }

    }
}
