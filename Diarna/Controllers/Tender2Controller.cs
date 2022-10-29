using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diarna.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using Diarna.DTOs.Tender2;
using System.Collections.Generic;
using Diarna.Data.Domain;
using System;

namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Tender2Controller : ControllerBase
    {
        private readonly ITender2 _tender2;
        private readonly IMapper _mapper;
        public Tender2Controller(ITender2 tender2, IMapper mapper)
        {
            _tender2 = tender2;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllTenders")]
        public async Task<IActionResult> GetAllTenders()
        {
            var result = await _tender2.GetAllTenders();
            var mapper = _mapper.Map<IEnumerable<ReadTender2Dto>>(result);
            return Ok(mapper);
        }


        [HttpGet("{id:int}", Name = "GetTenderById")]
        public async Task<IActionResult> GetTenderById(int id)
        {
            var result = await _tender2.GetTenderById(id);
            if (result == null)
                return StatusCode(500, "No Such id");
            //return NotFound();
            var mapper = _mapper.Map<ReadTender2Dto>(result);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddTender([FromBody] CreateTender2Dto createTender)
        {
            var mapper = _mapper.Map<TblTender>(createTender);
            var result = await _tender2.AddTender(mapper);
            if (result == null)
                return StatusCode(500, "No thing Added");
            return CreatedAtRoute(nameof(GetTenderById), new { Id = result.Id }, result);
            //return Ok("Added Successfully");
        }

        [HttpPut("{id}", Name = "UpdateTender")]
        public async Task<IActionResult> UpdateTender(int id, [FromBody] CreateTender2Dto createTender)
        {
            var returned = await _tender2.GetTenderById(id);
            _mapper.Map(createTender, returned);
            var result = await _tender2.UpdateTender(returned);
            var mapper = _mapper.Map<ReadTender2Dto>(result);
            if (mapper == null)
                return StatusCode(500, "No thing Updated");
            return Ok("Edited Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTender(int id)
        {
            var result = await _tender2.DeleteTender(id);
            if (result == null)
                return StatusCode(500, "No thing Deleted");
            return Ok("Deleted Successfully");
        }


    }
}
