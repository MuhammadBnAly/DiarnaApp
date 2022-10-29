using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diarna.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using Diarna.DTOs.RentedUnit2;
using System.Collections.Generic;
using Diarna.Data.Domain;
using System;

namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RentedUnit2Controller : ControllerBase
    {
        private readonly IRentedUnit2 _rentedUnit;
        private readonly IMapper _mapper;
        public RentedUnit2Controller(IRentedUnit2 rentedUnit, IMapper mapper)
        {
            this._rentedUnit = rentedUnit;
            this._mapper = mapper;
        }
        [HttpGet(Name = "GetAllRentedUnits2")]
        public async Task<IActionResult> GetAllRentedUnits2()
        {
            var result = await _rentedUnit.GetAllRentedUnits2();
            var mapper = _mapper.Map<IEnumerable<ReadRentedUnit2Dto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{id}", Name = "GetRentedUnitById2")]
        public async Task<IActionResult> GetRentedUnitById2(int id)
        {
            var result = await _rentedUnit.GetRentedUnitById2(id);
            if (result == null)
                return StatusCode(500, "No Such Id");
            var mapper = _mapper.Map<ReadRentedUnit2Dto>(result);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddRentedUnit2([FromBody] CreateRentedUnit2Dto dto)
        {
            var mapper = _mapper.Map<TblRentedUnit>(dto);
            var result = await _rentedUnit.AddRentedUnit2(mapper);

            return CreatedAtRoute(nameof(GetRentedUnitById2), new { id = result.Id }, result);
            if (result == null)
                return StatusCode(500, "No thing Added");
        }

        [HttpPut("{id}", Name = "UpdateRentedUnit2")]
        public async Task<IActionResult> UpdateRentedUnit2(int id , CreateRentedUnit2Dto dto)
        {
            var returned = await _rentedUnit.GetRentedUnitById2(id);
            _mapper.Map(dto, returned);
            var result = await _rentedUnit.UpdateRentedUnit2(returned);
            var mapper = _mapper.Map<ReadRentedUnit2Dto>(result);
            if (mapper == null)
                return StatusCode(500, "No thing Edited");
            //return Ok("Edited Successfully");
            return CreatedAtRoute(nameof(GetRentedUnitById2), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentedUnit2(int id)
        {
            var result = await _rentedUnit.DeleteRentedUnit2(id);
            if (result == null)
                return StatusCode(500, "No thing Deleted");
            return Ok("Deleted Successfully");
        }


        [HttpGet(Name = "GetAllRentedUnitsWithDetails2")]
        public async Task<IActionResult> GetAllRentedUnitsWithDetails2()
        {
            var result = await _rentedUnit.GetAllRentedUnitsWithDetails2();
            var mapper = _mapper.Map<IEnumerable<ReadAllRentedUnit2Dto>>(result);
            return Ok(mapper);
        }


    }
}
