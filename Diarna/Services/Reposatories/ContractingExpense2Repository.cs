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
    public class ContractingExpense2Repository : IContractingExpenses2
    {
        private readonly DiarnaContext _diarnaContext;
        public ContractingExpense2Repository(DiarnaContext diarnaContext)
        {
            _diarnaContext = diarnaContext;
        }

        public async Task<TblContractingExpnse> AddContractingExpenses(TblContractingExpnse tblContractingExpnse)
        {
            try
            {
                var result = await _diarnaContext.AddAsync(tblContractingExpnse);
                await _diarnaContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteContractingExpenses(int id)
        {
            try
            {
                var result = await GetContractingExpensesById2(id);
                if (result == null)
                    return false;
                _diarnaContext.TblContractingExpnses.Remove(result);
                await _diarnaContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TblContractingExpnse>> GetAllContractingExpenses2()
        {
            try
            {
                return await _diarnaContext.TblContractingExpnses.Include(n => n.Item)
                    .Include(n => n.Tender).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblContractingExpnse> GetContractingExpensesById2(int id)
        {
            try
            {
                return await _diarnaContext.TblContractingExpnses.Include(n => n.Item)
                    .Include(n => n.Tender).Where(n => n.Id == id).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblContractingExpnse> UpdateContractingExpenses(TblContractingExpnse tblContractingExpnse)
        {
            try
            {
                _diarnaContext.Entry(tblContractingExpnse).State = EntityState.Modified;
                await _diarnaContext.SaveChangesAsync();
                return tblContractingExpnse;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
