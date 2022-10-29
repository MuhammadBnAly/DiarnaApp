using AutoMapper;
using Diarna.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;
using Diarna.DTOs.Village2;

namespace Diarna.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Villages2Controller : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVillage2 _village2;

        public Villages2Controller(IMapper mapper, IVillage2 village2)
        {
            _village2 = village2;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllVillages2")]
        public async Task<ActionResult> GetAllVillages2()
        {
            var result = await _village2.GetAllVillages2();
            var mapper = _mapper.Map<IEnumerable<ReadVillage2Dto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{id:int}", Name = "GetVillageById2")]
        public async Task<ActionResult> GetVillageById2(int id)
        {
            var result = await _village2.GetVillageById2(id);
            if (result == null)
                return NoContent();
            var mapper = _mapper.Map<ReadVillage2Dto>(result);
            return Ok(mapper);
            //return Ok(result);
        }
        //[HttpGet("{id:int}", Name = "GetVillageById")]
        //public async Task<ActionResult> GetVillageById(int id)
        //{
        //    var result = await _village2.GetVillageById(id);
        //    var mapper = _mapper.Map<ReadVillage2Dto>(result);
        //    return Ok(mapper);
        //}

        [HttpPost]
        public async Task<IActionResult> AddVillage2([FromBody] CreateVillage2Dto createVillage2Dto)
        {
            //var village = await _village2.GetVillageByName(createVillage2Dto.Name);
            //var result = await _village2.AddVillage(_mapper.Map<TblVillage>(createVillage2Dto));
            //var mapper = _mapper.Map<ReadVillage2Dto>(result);


            //check for the village
            var village = await _village2.GetVillageByName2(createVillage2Dto.Name);
            if (village != null)
                return StatusCode(500, "this village is already exist");

            var result = await _village2.AddVillage2(_mapper.Map<TblVillage>(createVillage2Dto));

            var mapper = _mapper.Map<ReadVillage2Dto>(result);

            if (mapper != null)
                return Ok("Added successfully");
                //return CreatedAtRoute(nameof(GetAllVillages2), new { Id = result.Id }, mapper);
            return StatusCode(500, "No Item Added");

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateVillage2(int id , [FromBody] CreateVillage2Dto createVillage2Dto)
        {
            var returned = await _village2.GetVillageById2(id);
            if (returned == null)
                return NotFound();
            _mapper.Map( createVillage2Dto, returned);
            var result = await _village2.UpdateVillage2(returned);
            var mapper = _mapper.Map<ReadVillage2Dto>(result);
            if (mapper == null)
                return StatusCode(500, "No Item Updated");
            //return Ok("Updated Successfully");
            return CreatedAtRoute(nameof(GetVillageById2), new { Id = result.Id }, mapper);

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVillageById(int id)
        {
            var result = await _village2.DeleteVillageById2(id);
            if (result)
                return Ok("Deleted Successfully");
            return StatusCode(500, "No Item Deleted");

        }



    }
}
