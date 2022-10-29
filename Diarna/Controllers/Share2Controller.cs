using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diarna.Services.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.DTOs.Share2;
using Diarna.Data.Domain;

namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Share2Controller : ControllerBase
    {
        private readonly IShares2 _share2;
        private readonly IMapper _mapper;
        public Share2Controller(IShares2 shares2, IMapper mapper)
        {
            _share2 = shares2;
            _mapper = mapper;
        }

        //[HttpGet(Name = "GetAllShares2")]
        //public async Task<ActionResult> GetAllShares2()
        //{
        //    var result = await _share2.GetAllShares2();
        //    var mapper = _mapper.Map<IEnumerable<ReadShare2Dto>>(result);
        //    return Ok(mapper);
        //}


        [HttpGet(Name = "GetAllSharesWithDetails2")]
        public async Task<IActionResult> GetAllSharesWithDetails2()
        {
            var result = await _share2.GetAllSharesWithDetails2();
            var mapper = _mapper.Map<IEnumerable<ReadShareDetails2Dto>>(result);
            return Ok(mapper);
        }

        //[HttpGet("{id:int}", Name = "GetShareById2")]
        //public async Task<ActionResult> GetShareById2(int id)
        //{
        //    var result = await _share2.GetShareById2(id);
        //    if (result == null)
        //        return NotFound();
        //    var mapper = _mapper.Map<ReadShare2Dto>(result);
        //    return Ok(mapper);
        //}


        [HttpGet("{id:int}", Name = "GetShareWithDetailById2")]
        public async Task<IActionResult> GetShareWithDetailById2(int id)
        {
            var result = await _share2.GetShareWithDetailById2(id);
            if (result == null)
                return NotFound();
            var mapper = _mapper.Map<ReadShareDetails2Dto>(result);
            return Ok(mapper);


            
        }

        [HttpGet("{name}", Name = "GetShareWithDetailByName2")]
        public async Task<IActionResult> GetShareWithDetailByName2(string name)
        {
            var result = await _share2.GetShareWithDetailByName2(name);
            if (result == null)
                return NotFound();
            var mapper = _mapper.Map<ReadShareDetails2Dto>(result);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddShare2([FromBody] CreateShare2Dto createShare2Dto)
        {
            var mapper = _mapper.Map<TblShare>(createShare2Dto);
            var result = await _share2.AddShare2(mapper);
            if (result == null)
                return StatusCode(500, "No Shares Added");
            return CreatedAtRoute(nameof(GetAllSharesWithDetails2), new { Id = result.Id }, result);
        }

        [HttpPut("{id:int}", Name = "UpdateShare2")]
        public async Task<IActionResult> UpdateShare2(int id, [FromBody] CreateShare2Dto createShare2Dto)
        { 
            // var insert = new table{name = createShare2Dto.name, }

            var returned = await _share2.GetShareWithDetailById2(id);
            _mapper.Map(createShare2Dto, returned);
            var result = await _share2.UpdateShare2(returned);
            var mapper = _mapper.Map<ReadShareDetails2Dto>(result);
            if (mapper == null)
                return StatusCode(500, "No Shares Updated");
            return CreatedAtRoute(nameof(GetAllSharesWithDetails2), new { Id = result.Id }, mapper);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteShare2(int id)
        {
            var result = await _share2.DeleteShare2(id);
            if (result == null)
                return StatusCode(500, "No Shares Deleted");
            return Ok("Deleted Successfully");
        }



    }
}
