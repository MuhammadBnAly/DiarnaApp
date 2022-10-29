using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.Services.Interfaces;
using Diarna.Data.Domain;
using AutoMapper;
using Diarna.DTOs.SystemUserRegister;

namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SystemUserRegister2Controller : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISystemUserRegister2 _systemUserRegister;
        public SystemUserRegister2Controller(IMapper mapper, ISystemUserRegister2 systemUserRegister)
        {
            this._mapper = mapper;
            this._systemUserRegister = systemUserRegister;
        }

        [HttpGet(Name = "GetAllSystemUsers2")]
        public async Task<IActionResult> GetAllSystemUsers2()
        {
            var result = await _systemUserRegister.GetAllSystemUsers2();
            var mapper = _mapper.Map<IEnumerable<ReadSystemUser2Dto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{id}", Name = "GetSystemUserById2")]
        public async Task<IActionResult> GetSystemUserById2(int id)
        {
            var result = await _systemUserRegister.GetSystemUserById2(id);
            if(result == null)
                //return NotFound();
                return StatusCode(500, "No Such Id");
            var mapper = _mapper.Map<ReadSystemUser2Dto>(result);
            //return Ok(mapper);
            return CreatedAtRoute(nameof(GetSystemUserById2), new {id = result.Id}, result);

        }
        [HttpPost]
        public async Task<IActionResult> AddSystemUser2([FromBody] CreateSystemUser2Dto dto)
        {
            var mapper = _mapper.Map<TblSystemUser>(dto);
            var result = await _systemUserRegister.AddSystemUser2(mapper);
            if (mapper == null)
                return StatusCode(500, "No Thing Added");
            return CreatedAtRoute(nameof(GetSystemUserById2), new { id = result.Id }, result);

        }
        [HttpPut("{id}", Name = "UpdateSystemUser2")]
        public async Task<IActionResult> UpdateSystemUser2(int id, [FromBody] CreateSystemUser2Dto dto)
        {
            var returned = await _systemUserRegister.GetSystemUserById2(id);
            _mapper.Map(dto, returned);
            var result = await _systemUserRegister.UpdateSystemUser2(returned);
            var mapper = _mapper.Map<ReadSystemUser2Dto>(result);
            if (mapper == null)
                return StatusCode(500, "No Thing Added");
            return CreatedAtRoute(nameof(GetSystemUserById2), new { id = result.Id }, result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemUser2(int id)
        {
            var result = await _systemUserRegister.DeleteSystemUser2(id);
            if (result)
                return Ok("Deleted Successfully");
            return StatusCode(500, "No Such Id to Delete");
        }




    }
}
