using Diarna.Services.Interfaces;
using Diarna.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Diarna.Services.Reposatories
{
    public class RentExpense2Repository : IRentExpence2
    {
        private readonly DiarnaContext _context;
        public RentExpense2Repository(DiarnaContext diarnaContext)
        {
            _context = diarnaContext;
        }

        //public async Task<IEnumerable<TblRentExpense>> GetAllRentExpenses2()
        //{
        //    return await _context.TblRentExpenses.ToListAsync();
        //    //return await _context.TblRentExpenses.Include(n => n.Unit).Include(n => n.Item).ToListAsync();
        //}
        public async Task<IEnumerable<TblRentExpense>> GetAllRentExpensesWithDetails2()
        {
            return await _context.TblRentExpenses.Include(n => n.Unit).Include(n => n.Item).ToListAsync();
        }
        //public async Task<IEnumerable<TblRentExpense>> GetRentExpenseById2(int unitId, int? itemId)
        //{
        //    return await _context.TblRentExpenses.Include(x => x.Unit).Include(x => x.Item)
        //        .Where(x => x.UnitId == unitId && x.ItemId == itemId).ToListAsync();
        //}
        //public async Task<IEnumerable<TblRentExpense>> GetRentExpenseByUnitId2(int unitId)
        //{
        //    return await _context.TblRentExpenses.Include(x => x.Unit).Include(x => x.Item)
        //        .Where(x => x.UnitId == unitId).ToListAsync();
        //}
        public async Task<TblRentExpense> GetRentExpenseWithDetailsById2(int unitId, int? itemId, DateTime date)
        {
            return await _context.TblRentExpenses.Include(x => x.Unit).Include(x => x.Item)
                .Where(x => x.UnitId == unitId && x.ItemId == itemId && x.Date == date).FirstOrDefaultAsync();
        }
        public async Task<TblRentExpense> AddRentExpense2(TblRentExpense tblRentExpense)
        {
            try
            {
                var result = await _context.AddAsync(tblRentExpense);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TblRentExpense> UpdateRentExpense2(TblRentExpense tblRentExpense)
        {
            try
            {
                _context.Entry(tblRentExpense).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return tblRentExpense;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteRentExpense2(int unitId, int? itemId, DateTime date)
        {
            try
            {
                var result = await GetRentExpenseWithDetailsById2(unitId, itemId, date);
                if (result != null)
                {
                    _context.TblRentExpenses.Remove((TblRentExpense)result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }




    }
}
