using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diarna.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using Diarna.DTOs.Reservation2;
using System.Collections.Generic;
using Diarna.Data.Domain;
using System;


namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Reservation2Controller : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReservation2 _reservation;
        public Reservation2Controller(IMapper mapper, IReservation2 reservation)
        {
            this._mapper = mapper;
            this._reservation = reservation;
        }

        [HttpGet(Name = "GetAllReservations2")]
        public async Task<IActionResult> GetAllReservations2()
        {
            var result = await _reservation.GetAllReservations2();
            var mapper = _mapper.Map<IEnumerable<ReadReservation2Dto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{dateId}", Name = "GetAllReservationsWithDate2")]
        public async Task<IActionResult> GetAllReservationsWithDate2(int dateId)
        {
            var reservation = await _reservation.GetAllReservationsWithDate2(dateId);
            if (reservation == null)
                return NotFound();
            var mapper = _mapper.Map<IEnumerable<ReadReservation2Dto>>(reservation);
            return Ok(mapper);
        }

        [HttpGet("{unitId}", Name = "GetAllReservationsWithUnit2")]
        public async Task<IActionResult> GetAllReservationsWithUnit2(int unitId)
        {
            var reservation = await _reservation.GetAllReservationsWithUnit2(unitId);
            if (reservation == null)
                return NotFound();
            var mapper = _mapper.Map<IEnumerable<ReadReservation2Dto>>(reservation);
            return Ok(mapper);
        }

        [HttpGet("{unitId},{dateId}", Name = "GetReservationByIdAndDate2")]
        public async Task<IActionResult> GetReservationByIdAndDate2(int unitId, int dateId)
        {
            var result = await _reservation.GetReservationByIdAndDate2(unitId, dateId);
            if (result == null)
                return NotFound();
            var mapper = _mapper.Map<ReadReservation2Dto>(result);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation2([FromBody] CreateReservation2Dto dto)
        {
            var mapper = _mapper.Map<TblReservation>(dto);
            var result = await _reservation.AddReservation2(mapper);
            if (result == null)
                return StatusCode(500, "No thing Added");
            //return Ok(result);
            //return Ok("Successfully Added");
            return CreatedAtRoute(nameof(GetReservationByIdAndDate2),
                new { unitId = result.UnitId, dateId = result.DateId }, result);
        }

        [HttpPut("{unitId},{dateId}", Name = "UpdateReservation2")]
        public async Task<IActionResult> UpdateReservation2(int unitId, int dateId, [FromBody] CreateReservation2Dto dto)
        {
            var returned = await _reservation.GetReservationByIdAndDate2(dto.UnitId = unitId, dto.DateId = dateId);
            _mapper.Map(dto, returned);
            var result = await _reservation.UpdateReservation2(returned);
            var mapper = _mapper.Map<ReadReservation2Dto>(result);
            if (mapper == null)
                return StatusCode(500, "No thing Edited");
            return Ok(mapper);
            //return CreatedAtRoute(nameof(GetReservationByIdAndDate2),
            //    new { unitId = result.UnitId, dateId = result.DateId }, result);
        }

        [HttpDelete("{unitId},{dateId}", Name = "DeleteReservation2")]
        public async Task<IActionResult> DeleteReservation2(int unitId, int dateId)
        {
            var result = await _reservation.DeleteReservation2(unitId, dateId);
            if(result == null)
                return StatusCode(500, "No thing Deleted");
            return Ok("Deleted Successfully");
        }




    }
}
