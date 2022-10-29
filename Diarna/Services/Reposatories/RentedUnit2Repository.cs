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
    public class RentedUnit2Repository : IRentedUnit2
    {
        private readonly DiarnaContext _diarnaContext;
        public RentedUnit2Repository(DiarnaContext diarnaContext)
        {
            this._diarnaContext = diarnaContext;
        }

        public async Task<IEnumerable<TblRentedUnit>> GetAllRentedUnits2()
        {
            try
            {
                return await _diarnaContext.TblRentedUnits.Include(n => n.Unit).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblRentedUnit> GetRentedUnitById2(int id)
        {
            try
            {
                return await _diarnaContext.TblRentedUnits.Include(n => n.Unit).SingleOrDefaultAsync(n => n.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblRentedUnit> AddRentedUnit2(TblRentedUnit tblRentedUnit)
        {
            try
            {
                var result = await _diarnaContext.AddAsync(tblRentedUnit);
                await _diarnaContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<TblRentedUnit> UpdateRentedUnit2(TblRentedUnit tblRentedUnit)
        {
            try
            {
                _diarnaContext.Entry(tblRentedUnit).State = EntityState.Modified;
                await _diarnaContext.SaveChangesAsync();
                return tblRentedUnit;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteRentedUnit2(int id)
        {
            try
            {
                var result = await GetRentedUnitById2(id);
                if (result == null)
                    return false;
                _diarnaContext.TblRentedUnits.Remove(result);
                await _diarnaContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TblRentedUnit>> GetAllRentedUnitsWithDetails2()
        {
            try
            {
                //Tbl Rented Users
                return await _diarnaContext.TblRentedUnits
                    .Include(n => n.Unit)
                    .Include(n => n.Unit.Building.Village)
                    //.Include(n => n.)
                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
