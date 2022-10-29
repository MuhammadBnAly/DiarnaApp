using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diarna.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using Diarna.DTOs.Item2;
using System.Collections.Generic;
using Diarna.Data.Domain;
using System;
namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Item2Controller : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IItem2 _item;
        public Item2Controller(IMapper mapper, IItem2 item)
        {
            this._item = item;
            this._mapper = mapper;
        }

        [HttpGet(Name = "GetAllItems2")]
        public async Task<IActionResult> GetAllItems2()
        {
            var result = await _item.GetAllItems2();
            var mapper = _mapper.Map<IEnumerable<ReadItem2Dto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{id}", Name = "GetItemById2")]
        public async Task<IActionResult> GetItemById2(int id)
        {
            var result = await _item.GetItemById2(id);
            if (result == null)
                return StatusCode(500, "No Such id");
            //return NotFound();
            var mapper = _mapper.Map<ReadItem2Dto>(result);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem2([FromBody] CreateItem2Dto dto)
        {
            var mapper = _mapper.Map<TblItem>(dto);
            var result = await _item.AddItem2(mapper);
            if (result == null)
                return StatusCode(500, "No thing Added");
            return CreatedAtRoute(nameof(GetItemById2), new { Id = result.Id }, result);
            //return Ok("Added Successfully");
        }

        [HttpPut("{id}", Name = "UpdateItem2")]
        public async Task<IActionResult> UpdateItem2(int id, [FromBody] CreateItem2Dto dto)
        {
            var returned = await _item.GetItemById2(id);
            _mapper.Map(dto, returned);
            var result = await _item.UpdateItem2(returned);
            var mapper = _mapper.Map<ReadItem2Dto>(result);
            if (mapper == null)
                return StatusCode(500, "No thing Updated");
            return Ok("Edited Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem2(int id)
        {
            var result = await _item.DeleteItem2(id);
            if (result == null)
                return StatusCode(500, "No thing Deleted");
            return Ok("Deleted Successfully");
        }



    }
}
