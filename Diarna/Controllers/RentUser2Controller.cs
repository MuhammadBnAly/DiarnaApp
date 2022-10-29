using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diarna.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using Diarna.DTOs.RentUser2;
using System.Collections.Generic;
using Diarna.Data.Domain;
using System;
namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RentUser2Controller : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRentUser2 _rentUser;
        public RentUser2Controller(IRentUser2 rentUser, IMapper mapper)
        {
            this._mapper = mapper;
            this._rentUser = rentUser;
        }

        [HttpGet(Name = "GetAllRentUsers2")]
        public async Task<IActionResult> GetAllRentUsers2()
        {
            var result = await _rentUser.GetAllRentUsers2();
            var mapper = _mapper.Map<IEnumerable<ReadRentUser2Dto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{id}", Name = "GetRentUserById2")]
        public async Task<IActionResult> GetRentUserById2(int id)
        {
            var result = await _rentUser.GetRentUserById2(id);
            if (result == null)
                return StatusCode(500, "No Such id");
            //return NotFound();
            var mapper = _mapper.Map<ReadRentUser2Dto>(result);
            return Ok(mapper);
        }

        [HttpGet("{mobile}", Name = "GetRentUserByMobile2")]
        public async Task<IActionResult> GetRentUserByMobile2(string mobile)
        {
            var result = await _rentUser.GetRentUserByMobile2(mobile);
            if (result == null)
                return StatusCode(500, "No Such id");
            //return NotFound();
            var mapper = _mapper.Map<ReadRentUser2Dto>(result);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddRentUser2([FromBody] CreateRentUser2Dto dto)
        {
            var mapper = _mapper.Map<TblRentUser>(dto);
            var result = await _rentUser.AddRentUser2(mapper);
            if (result == null)
                return StatusCode(500, "No thing Added");
            return CreatedAtRoute(nameof(GetRentUserById2), new { Id = result.Id }, result);
            //return Ok("Added Successfully");
        }

        [HttpPut("{id}", Name = "UpdateRentUserById2")]
        public async Task<IActionResult> UpdateRentUserById2(int id, [FromBody] CreateRentUser2Dto dto)
        {
            var returned = await _rentUser.GetRentUserById2(id);
            _mapper.Map(dto, returned);
            var result = await _rentUser.UpdateRentUser2(returned);
            var mapper = _mapper.Map<ReadRentUser2Dto>(result);
            if (mapper == null)
                return StatusCode(500, "No thing Updated");
            return Ok("Edited Successfully");
        }


        [HttpPut("{mobile}", Name = "UpdateRentUserByMobile2")]
        public async Task<IActionResult> UpdateRentUserByMobile2(string mobile, [FromBody] CreateRentUser2Dto dto)
        {
            var returned = await _rentUser.GetRentUserByMobile2(mobile);
            _mapper.Map(dto, returned);
            var result = await _rentUser.UpdateRentUser2(returned);
            var mapper = _mapper.Map<ReadRentUser2Dto>(result);
            if (mapper == null)
                return StatusCode(500, "No thing Updated");
            return Ok("Edited Successfully");
        }

        [HttpDelete("{id}", Name = "DeleteRentUserById2")]
        //[HttpDelete(Name = "DeleteRentUserById2")]
        public async Task<IActionResult> DeleteRentUserById2(int id)
        {
            var result = await _rentUser.DeleteRentUserById2(id);
            if (result)
                return Ok("Deleted Successfully");
            return StatusCode(500, "No thing Deleted");
        }

        [HttpDelete("{mobile}", Name = "DeleteRentUserByMobile2")]
        //[HttpDelete(Name = "DeleteRentUserByMobile2")]
        public async Task<IActionResult> DeleteRentUserByMobile2(string mobile)
        {
            var result = await _rentUser.DeleteRentUserByMobile2(mobile);
            if (result)
                return Ok("Deleted Successfully");
            return StatusCode(500, "No thing Deleted");
        }


    }
}
