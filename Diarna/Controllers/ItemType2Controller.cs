using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diarna.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using Diarna.DTOs.ItemType2;
using System.Collections.Generic;
using Diarna.Data.Domain;
using System;

namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemType2Controller : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IItemType2 _itemType;
        public ItemType2Controller(IItemType2 itemType, IMapper mapper)
        {
            this._mapper = mapper;
            this._itemType = itemType;
        }

        [HttpGet(Name = "GetAllItemTypes2")]
        public async Task<IActionResult> GetAllItemTypes2()
        {
            var result = await _itemType.GetAllItemTypes2();
            var mapper = _mapper.Map<IEnumerable<ReatItemType2Dto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{id}", Name = "GetItemTypeById2")]
        public async Task<IActionResult> GetItemTypeById2(int id)
        {
            var result = await _itemType.GetItemTypeById2(id);
            if (result == null)
                return StatusCode(500, "No Such id");
            //return NotFound();
            var mapper = _mapper.Map<ReatItemType2Dto>(result);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemType2([FromBody] CreateItemType2Dto dto)
        {
            var mapper = _mapper.Map<TblItemType>(dto);
            var result = await _itemType.AddItemType2(mapper);
            if (result == null)
                return StatusCode(500, "No thing Added");
            return CreatedAtRoute(nameof(GetItemTypeById2), new { Id = result.Id }, result);
            //return Ok("Added Successfully");
        }

        [HttpPut("{id}", Name = "UpdateItemType2")]
        public async Task<IActionResult> UpdateItemType2(int id, [FromBody] CreateItemType2Dto dto)
        {
            var returned = await _itemType.GetItemTypeById2(id);
            _mapper.Map(dto, returned);
            var result = await _itemType.UpdateItemType2(returned);
            var mapper = _mapper.Map<ReatItemType2Dto>(result);
            if (mapper == null)
                return StatusCode(500, "No thing Updated");
            return Ok("Edited Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemType2(int id)
        {
            var result = await _itemType.DeleteItemType2(id);
            if (result == null)
                return StatusCode(500, "No thing Deleted");
            return Ok("Deleted Successfully");
        }


    }
}
