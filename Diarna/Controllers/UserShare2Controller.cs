using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diarna.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using Diarna.DTOs.UserShare2;
using System.Collections.Generic;
using Diarna.Data.Domain;
using System;
namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserShare2Controller : ControllerBase
    {
        private readonly IUserShare2 _userShare;
        private readonly IMapper _mapper;
        public UserShare2Controller(IUserShare2 userShare, IMapper mapper)
        {
            this._userShare = userShare;
            this._mapper = mapper;
        }
        [HttpGet(Name = "GetAllUserShare2")]
        public async Task<IActionResult> GetAllUserShare2()
        {
            var result = await _userShare.GetAllUserShare2();
            var mapper = _mapper.Map<IEnumerable<ReadUserShare2Dto>>(result);
            return Ok(mapper);
        }
        [HttpGet("{id}", Name = "GetUserShareById2")]
        public async Task<IActionResult> GetUserShareById2(int id)
        {
            var result = await _userShare.GetUserShareById2(id);
            if (result == null)
                return StatusCode(500, "No Such id");
            //return NotFound();
            var mapper = _mapper.Map<ReadUserShare2Dto>(result);
            return Ok(mapper);
        }
        [HttpPost]
        public async Task<IActionResult> AddUserShare2([FromBody] CreateUserShare2Dto dto)
        {
            var mapper = _mapper.Map<TblUserShare>(dto);
            var result = await _userShare.AddUserShare2(mapper);
            if (result == null)
                return StatusCode(500, "No thing Added");
            return CreatedAtRoute(nameof(GetUserShareById2), new { Id = result.Id }, result);
            //return Ok("Added Successfully");
        }

        [HttpPut("{id}", Name = "UpdateUserShare2")]
        public async Task<IActionResult> UpdateUserShare2(int id, [FromBody] CreateUserShare2Dto dto)
        {
            var returned = await _userShare.GetUserShareById2(id);
            _mapper.Map(dto, returned);
            var result = await _userShare.UpdateUserShare2(returned);
            var mapper = _mapper.Map<ReadUserShare2Dto>(result);
            if (mapper == null)
                return StatusCode(500, "No thing Updated");
            return Ok("Edited Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserShare2(int id)
        {
            var result = await _userShare.DeleteUserShare2(id);
            if (result)
                return Ok("Deleted Successfully");
            return StatusCode(500, "No thing Deleted");
        }


    }
}
