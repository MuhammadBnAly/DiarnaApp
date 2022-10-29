using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diarna.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using Diarna.DTOs.ReserveNewUnit2;
using System.Collections.Generic;
using Diarna.Data.Domain;
using System;
namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReservedNewUnit2Controller : ControllerBase
    {
        private readonly IReserveNewUnit2 _reserveNewUnit;
        private readonly IMapper _mapper;
        private readonly IReservation2 _reservation;
        public ReservedNewUnit2Controller(IReserveNewUnit2 reserveNewUnit, IMapper mapper, IReservation2 reservation)
        {
            this._reserveNewUnit = reserveNewUnit;
            this._mapper = mapper;
            this._reservation = reservation;
        }

            
        [HttpGet(Name = "GetAllReservedUnits2")]
        public async Task<IActionResult> GetAllReservedUnits2()
        {
            var result = await _reserveNewUnit.GetAllReservedUnits2();
            var mapper = _mapper.Map<IEnumerable<ReadReservedUnitSimple2Dto>>(result);
            return Ok(mapper);
        }

        //[HttpGet(Name = "GetAllAvailableUnits2")]
        //public async Task<IActionResult> GetAllAvailableUnits2()
        //{
        //    var result = await _reserveNewUnit.GetAllAvailableUnits2();
        //    var mapper = _mapper.Map<IEnumerable<ReadReservedUnitSimple2Dto>>(result);
        //    return Ok(mapper);
        //}

        [HttpGet("{date}", Name = "GetUnitsByOneDate2")]
        public async Task<IActionResult> GetUnitsByOneDate2(DateTime date)
        {
            var result = await _reserveNewUnit.GetUnitsByOneDate2(date);
            if (result == null)
                return StatusCode(500, "Not Found");
            var mapper = _mapper.Map<IEnumerable<ReadReservedUnit2Dto>>(result);
            if (mapper != null)
                return Ok(mapper);
            return StatusCode(500, "Not Reserved Yet");
            //return CreatedAtRoute(nameof(_reservation.AddReservation2), date);
        }

        [HttpGet("{startDate},{endDate}", Name = "GetAllReservedUnitsWithDate2")]
        public async Task<IActionResult> GetAllReservedUnitsWithDate2(DateTime startDate, DateTime endDate)
        {
            var reservation = await _reserveNewUnit.GetAllReservedUnitsWithDate2( startDate,  endDate);
            if (reservation == null)
                return NotFound();
            var mapper = _mapper.Map<IEnumerable<ReadOnlyUnit2Dto>>(reservation);
            if (mapper != null)
                return Ok(mapper);
            return StatusCode(500, "Not Reserved Yet");
        }

        [HttpGet("{startDate},{endDate}", Name = "GetAvailableDatesForUnit2")]
        public async Task<IActionResult> GetAvailableDatesForUnit2(DateTime startDate, DateTime endDate)
        {
            var reservation = await _reserveNewUnit.GetAvailableDatesForUnit2(startDate, endDate);
            if (reservation == null)
                return NotFound();
            var mapper = _mapper.Map<IEnumerable<ReadOnlyUnit2Dto>>(reservation);
            if (mapper != null)
                return Ok(mapper);
            return StatusCode(500, "Not Reserved Yet");
        }

        //
        //

        //GetAllReservedUnitsWithUnit2(int unitId)
        [HttpGet("{unitId}", Name = "GetAllReservedUnitsWithUnit2")]
        public async Task<IActionResult> GetAllReservedUnitsWithUnit2(int unitId)
        {
            var reservation = await _reserveNewUnit.GetAllReservedUnitsWithUnit2(unitId);
            if (reservation == null)
                return NotFound();
            var mapper = _mapper.Map<IEnumerable<ReadReservedUnit2Dto>>(reservation);
            return Ok(mapper);
        }


        //GetAvailableDatesForUnit(DateTime startDate, DateTime endDate, int unitId)
        [HttpGet("{startDate},{endDate},{unitId}", Name = "GetAvailableDatesForUnit")]
        public async Task<IActionResult> GetAvailableDatesForUnit(DateTime startDate, DateTime endDate, int unitId)
        {
            var reservation = await _reserveNewUnit.GetAvailableDatesForUnit(startDate, endDate, unitId);
            if (reservation == null)
                return NotFound();
            var mapper = _mapper.Map<IEnumerable<ReadReservedUnit2Dto>>(reservation);
            return Ok(mapper);
        }


        //GetBusyDatesForUnit(DateTime startDate, DateTime endDate, int unitId)
        [HttpGet("{startDate},{endDate},{unitId}", Name = "GetBusyDatesForUnit")]
        public async Task<IActionResult> GetBusyDatesForUnit(DateTime startDate, DateTime endDate, int unitId)
        {
            var reservation = await _reserveNewUnit.GetBusyDatesForUnit(startDate, endDate, unitId);
            if (reservation == null)
                return NotFound();
            var mapper = _mapper.Map<IEnumerable<ReadReservedUnit2Dto>>(reservation);
            return Ok(mapper);
        }


    }
}
