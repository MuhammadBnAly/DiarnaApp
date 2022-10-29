using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diarna.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using Diarna.DTOs.RentExpense;
using System.Collections.Generic;
using Diarna.Data.Domain;
using System;

namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RentExpense2Controller : ControllerBase
    {
        private readonly IRentExpence2 _rentExpense;
        private readonly IMapper _mapper;
        public RentExpense2Controller(IRentExpence2 rentExpense, IMapper mapper)
        {
            _rentExpense = rentExpense;
            _mapper = mapper;
        }

        //[HttpGet(Name = "GetAllRentExpenses2")]
        //public async Task<ActionResult> GetAllRentExpenses2()
        //{
        //    var result = await _rentExpense.GetAllRentExpenses2();
        //    var mapper = _mapper.Map<IEnumerable<ReadRentExpenseDto>>(result);
        //    return Ok(mapper);
        //}

        //[HttpGet("{unitId}", Name = "GetRentExpenseById2")]
        //public async Task<ActionResult> GetRentExpenseById2(int unitId, int? itemId)
        //{
        //    var result = await _rentExpense.GetRentExpenseById2(unitId, itemId);
        //    if (result == null)
        //        return NotFound();
        //    var mapper = _mapper.Map<IEnumerable<ReadRentExpenseDto>>(result);
        //    return Ok(mapper);
        //}

        [HttpGet(Name = "GetAllRentExpensesWithDetails2")]
        public async Task<IActionResult> GetAllRentExpensesWithDetails2()
        {
            var result = await _rentExpense.GetAllRentExpensesWithDetails2();
            var mapper = _mapper.Map<IEnumerable<ReadRentExpenseWithDetailsDto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{unitId:int}, {itemId:int},{date:DateTime}", Name = "GetRentExpenseWithDetailsById2")]
        public async Task<IActionResult> GetRentExpenseWithDetailsById2(int unitId, int itemId, DateTime date)
        {
            var result = await _rentExpense.GetRentExpenseWithDetailsById2(unitId, itemId, date);
            if (result == null)
                return NotFound();
            var mapper = _mapper.Map<ReadRentExpenseWithDetailsDto>(result);
            return Ok(mapper);
        }

        //[HttpGet("unitId", Name = "GetRentExpenseByUnitId2")]
        //public async Task<ActionResult> GetRentExpenseByUnitId2(int unitId)
        //{
        //    var result = await _rentExpense.GetRentExpenseByUnitId2(unitId);
        //    if (result == null)
        //        return NotFound();
        //    var mapper = _mapper.Map<IEnumerable<ReadRentExpenseWithDetailsDto>>(result);
        //    return Ok(mapper);
        //}



        [HttpPost]
        public async Task<IActionResult> AddRentExpense2([FromBody] CreateRentExpenseWithDetailsDto CreateDto)
        {
            //var checkResult = await _rentExpense.GetRentExpenseById2((int)CreateDto.ItemId);

            var result = await _rentExpense.AddRentExpense2(_mapper.Map<TblRentExpense>(CreateDto));
            if (result != null)
                //return Ok("Successfully Added");
                return CreatedAtRoute(nameof(GetRentExpenseWithDetailsById2), 
                    new { unitId = result.UnitId, itemId = result.ItemId }, 
                    result);
            return StatusCode(500, "No Item Added");

        }

        [HttpPut("{unitId},{itemId},{date}", Name = "UpdateRentExpense2")]
        public async Task<IActionResult> UpdateRentExpense2(int unitId, int itemId, DateTime date, [FromBody] CreateRentExpenseWithDetailsDto editDto)
        {
            //var returned = await _rentExpense.GetRentExpenseWithDetailsById2( id , editDto.ItemId);
            //_mapper.Map(editDto, returned);
            //var result = await _rentExpense.UpdateRentExpense2((TblRentExpense)returned);
            //var mapper = _mapper.Map<ReadRentExpenseWithDetailsDto>(result);

            var returned = await _rentExpense.GetRentExpenseWithDetailsById2(editDto.UnitId = unitId, editDto.ItemId = itemId, editDto.Date = date);
            _mapper.Map(editDto, returned);
            var result = await _rentExpense.UpdateRentExpense2(returned);
            var mapper = _mapper.Map<ReadRentExpenseDto>(result);
            if (mapper != null)
                return Ok("Edited Successfully");
            return StatusCode(500, "No thing Edited");
        }

        [HttpDelete( Name = "DeleteRentExpense2")]
        public async Task<IActionResult> DeleteRentExpense2(int unitId, int itemId, DateTime date)
        {
            var result = await _rentExpense.DeleteRentExpense2(unitId, itemId, date);
            if (result)
                return Ok("item Deleted Succefully");
            return StatusCode(500, "No Item Deleted");
        }

    }
}