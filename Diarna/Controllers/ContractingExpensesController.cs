using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diarna.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using Diarna.DTOs.ContractingExpenses;
using System.Collections.Generic;
using Diarna.Data.Domain;
using System;

namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContractingExpensesController : ControllerBase
    {
        private readonly IContractingExpenses2 _contractingExpenses2;
        private readonly IMapper _mapper;
        public ContractingExpensesController(IContractingExpenses2 contractingExpenses2, IMapper mapper)
        {
            _contractingExpenses2 = contractingExpenses2;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllContractingExpenses2")]
        public async Task<IActionResult> GetAllContractingExpenses2()
        {
            var result = await _contractingExpenses2.GetAllContractingExpenses2();
            var mapper = _mapper.Map<IEnumerable<ReadContractingExpensesDto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{id:int}", Name = "GetContractingExpensesById2")]
        public async Task<IActionResult> GetContractingExpensesById2(int id)
        {
            var result = await _contractingExpenses2.GetContractingExpensesById2(id);
            if (result == null)
                return StatusCode(500, "No Such id");
                //return NotFound();
            var mapper = _mapper.Map<ReadContractingExpensesDto>(result);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddContractingExpenses([FromBody] CreateContractingExpensesDto createContracting)
        {
            var mapper = _mapper.Map<TblContractingExpnse>(createContracting);
            var result = await _contractingExpenses2.AddContractingExpenses(mapper);
            if (result == null)
                return StatusCode(500, "No thing Added");
            return CreatedAtRoute(nameof(GetContractingExpensesById2), new { Id = result.Id }, result);
            //return Ok("Added Successfully");
        }

        [HttpPut("{id}", Name = "UpdateContractingExpenses")]
        public async Task<IActionResult> UpdateContractingExpenses(int id, [FromBody]CreateContractingExpensesDto createContracting)
        {
            var returned = await _contractingExpenses2.GetContractingExpensesById2(id);
            _mapper.Map(createContracting, returned);
            var result = await _contractingExpenses2.UpdateContractingExpenses(returned);
            var mapper = _mapper.Map<ReadContractingExpensesDto>(result);
            if (mapper == null)
                return StatusCode(500, "No thing Updated");
            return Ok("Edited Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContractingExpenses(int id)
        {
            var result = await _contractingExpenses2.DeleteContractingExpenses(id);
            if (result == null)
                return StatusCode(500, "No thing Deleted");
            return Ok("Deleted Successfully");
        }


    }
}
