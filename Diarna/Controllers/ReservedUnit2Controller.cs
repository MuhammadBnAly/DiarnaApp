using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diarna.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using Diarna.DTOs.ReservedUnit2;
using System.Collections.Generic;
using Diarna.Data.Domain;
using System;

namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReservedUnit2Controller : ControllerBase
    {
        private readonly IReservedUnit2 _reservedUnit;
        private readonly IMapper _mapper;
        public ReservedUnit2Controller(IReservedUnit2 reservedUnit, IMapper mapper)
        {
            this._reservedUnit = reservedUnit;
            this._mapper = mapper;
        }
        [HttpGet(Name = "GetAllReservedUnits2")]
        public async Task<IActionResult> GetAllReservedUnits2()
        {
            var result = await _reservedUnit.GetAllReservedUnits2();
            var mapper = _mapper.Map<IEnumerable<ReadReservedUnit2Dto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{unitId},{dateId}",Name = "GetReservedUnitById2")]
        public async Task<IActionResult> GetReservedUnitById2(int unitId, int dateId)
        {
            var result = await _reservedUnit.GetReservedUnitById2(unitId, dateId);
            if(result == null)
                //return NotFound();
                return StatusCode(500, "No Such ID");
            var mapper = _mapper.Map<ReadReservedUnit2Dto>(result);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservedUnit2([FromBody]CreateReservedUnit2Dto dto)
        {
            var mapper = _mapper.Map<TblReservation>(dto);
            var result = await _reservedUnit.AddReservedUnit2(mapper);
            if (result == null)
                return StatusCode(500, "No thing Added");
            //return Ok(result);
            return CreatedAtRoute(nameof(GetReservedUnitById2), 
                new {unitId = dto.UnitId, dateId = dto.DateId} ,result);

        }
        [HttpPut("{unitId},{dateId}", Name = "UpdateReservedUnit2")]
        public async Task<IActionResult> UpdateReservedUnit2(int unitId, int dateId , [FromBody] CreateReservedUnit2Dto dto)
        {
            var returned = await _reservedUnit.GetReservedUnitById2(dto.UnitId , dto.DateId);
            _mapper.Map(dto, returned);
            var result = await _reservedUnit.UpdateReservedUnit2(returned);
            var mapper = _mapper.Map<ReadReservedUnit2Dto>(result);
            if (mapper == null)
                return StatusCode(500, "No thing Updated");
            return Ok("Edited Successfully");
        }

        [HttpDelete("{unitId},{dateId}", Name = "DeleteReservedUnit2")]
        public async Task<IActionResult> DeleteReservedUnit2(int unitId, int dateId)
        {
            var result = await _reservedUnit.DeleteReservedUnit2(unitId, dateId);
            if (result)
                return Ok("Deleted Successfully");
            return StatusCode(500, "Not Deleted Yet");
        }

    }
}
