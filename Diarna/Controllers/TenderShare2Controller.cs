using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diarna.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using Diarna.DTOs.TenderShare2;
using System.Collections.Generic;
using Diarna.Data.Domain;
using System;
namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TenderShare2Controller : ControllerBase
    {
        private readonly ITenderShare2 _tenderShare;
        private readonly IMapper _mapper;
        public TenderShare2Controller(ITenderShare2 tenderShare, IMapper mapper)
        {
            _tenderShare = tenderShare;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllTenderShares")]
        public async Task<IActionResult> GetAllTenderShares()
        {
            var result = await _tenderShare.GetAllTenderShares();
            var mapper = _mapper.Map<IEnumerable<ReadTenderShare2Dto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{tenderId},{shareId},{year}", Name = "GetTenderShareById")]
        public async Task<IActionResult> GetTenderShareById(int tenderId, int shareId, int year)
        { 
            // sum of all income 
            //var sum = _repo.getIncomesum(); 

            //var sum = _repo2.getOUtcomesum();

            // result = sum -sum 
            //sum of all outcome 
            var result = await _tenderShare.GetTenderShareById( tenderId,  shareId,  year);
            if (result == null)
                return StatusCode(500, "No Such id");
            //return NotFound();
            var mapper = _mapper.Map<ReadTenderShare2Dto>(result);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddTenderShare([FromBody] CreateTenderShare2Dto dto)
        {
            var mapper = _mapper.Map<TblTenderShare>(dto);
            //var New = new TblTenderShare { TenderId = dto.TenderId };
            var result = await _tenderShare.AddTenderShare(mapper);
            if (result == null)
                return StatusCode(500, "No thing Added");
            return CreatedAtRoute(nameof(GetTenderShareById), 
                new { tenderId = result.TenderId , shareId = result.SharesId , year = result.Year}, 
                result);
            //return Ok("Added Successfully");
        }

        [HttpPut("{tenderId},{shareId},{year}", Name = "UpdateTenderShare")]
        public async Task<IActionResult> UpdateTenderShare(int tenderId, int shareId, int year, [FromBody] CreateTenderShare2Dto dto)
        {
            var returned = await _tenderShare.GetTenderShareById(tenderId, shareId, year);
            _mapper.Map(dto, returned);
            var result = await _tenderShare.UpdateTenderShare(returned);
            var mapper = _mapper.Map<ReadTenderShare2Dto>(result);
            if (mapper == null)
                return StatusCode(500, "No thing Updated");
            return Ok("Edited Successfully");
        }

        [HttpDelete("{tenderId},{shareId},{year}", Name = "DeleteTenderShare")]
        public async Task<IActionResult> DeleteTenderShare(int tenderId, int shareId, int year)
        {
            var result = await _tenderShare.DeleteTenderShare(tenderId, shareId, year);
            if (result == null)
                return StatusCode(500, "No thing Deleted");
            return Ok("Deleted Successfully");
        }



    }
}
