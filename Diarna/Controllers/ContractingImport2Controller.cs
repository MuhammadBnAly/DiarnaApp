using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diarna.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using Diarna.DTOs.ContractingImports;
using System.Collections.Generic;
using Diarna.Data.Domain;
using System;

namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContractingImport2Controller : ControllerBase
    {
        private readonly IContractingImport2 _contractingImport;
        private readonly IMapper _mapper;
        public ContractingImport2Controller(IContractingImport2 contractingImport, IMapper mapper)
        {
            this._contractingImport = contractingImport;
            this._mapper = mapper;
        }

        [HttpGet(Name = "GetAllContractingImports2")]
        public async Task<IActionResult> GetAllContractingImports2()
        {
            var result = await _contractingImport.GetAllContractingImports2();
            var mapper = _mapper.Map<IEnumerable<ReadContractingImports2Dto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{id}", Name = "GetContractingImportById2")]
        public async Task<IActionResult> GetContractingImportById2(int id)
        {
            var result = await _contractingImport.GetContractingImportById2(id);
            if (result == null)
                return StatusCode(500, "No Such id");
            //return NotFound();
            var mapper = _mapper.Map<ReadContractingImports2Dto>(result);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddContractingImport([FromBody] CreateContractingImport2Dto createContracting)
        {
            var mapper = _mapper.Map<TblContractingImport>(createContracting);
            var result = await _contractingImport.AddContractingImport(mapper);
            if (result == null)
                return StatusCode(500, "No thing Added");
            return CreatedAtRoute(nameof(GetContractingImportById2), new { Id = result.Id }, result);
            //return Ok("Added Successfully");
        }

        [HttpPut("{id}", Name = "UpdateContractingImport")]
        public async Task<IActionResult> UpdateContractingImport(int id, [FromBody] CreateContractingImport2Dto createContracting)
        {
            var returned = await _contractingImport.GetContractingImportById2(id);
            _mapper.Map(createContracting, returned);
            var result = await _contractingImport.UpdateContractingImport(returned);
            var mapper = _mapper.Map<ReadContractingImports2Dto>(result);
            if (mapper == null)
                return StatusCode(500, "No thing Updated");
            return Ok("Edited Successfully");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContractingImport(int id)
        {
            var result = await _contractingImport.DeleteContractingImport(id);
            if (result == null)
                return StatusCode(500, "No thing Deleted");
            return Ok("Deleted Successfully");
        }


    }
}
