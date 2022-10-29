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
    public class Unit2Repository : IUnit2
    {
        private readonly DiarnaContext _diarnaContext;
        public Unit2Repository(DiarnaContext diarnaContext)
        {
            this._diarnaContext = diarnaContext;
        }
        public async Task<IEnumerable<TblUnit>> GetAllUnits2()
        {
            try
            {
                return await _diarnaContext.TblUnits.Include(n => n.Building).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblUnit> GetUnitById2(int id)
        {
            try
            {
                return await _diarnaContext.TblUnits.Include(n => n.Building).SingleOrDefaultAsync( n=> n.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblUnit> AddUnit2(TblUnit tblUnit)
        {
            try
            {
                var result = await _diarnaContext.AddAsync(tblUnit);
                await _diarnaContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<TblUnit> UpdateUnit2(TblUnit tblUnit)
        {
            try
            {
                _diarnaContext.Entry(tblUnit).State = EntityState.Modified;
                await _diarnaContext.SaveChangesAsync();
                return tblUnit;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteUnit2(int id)
        {
            try
            {
                var result = await GetUnitById2(id);
                if (result == null)
                    return false;
                _diarnaContext.TblUnits.Remove(result);
                await _diarnaContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



    }
}
