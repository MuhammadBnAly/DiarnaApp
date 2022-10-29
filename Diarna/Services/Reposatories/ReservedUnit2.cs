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
    public class ReservedUnit2 : IReservedUnit2
    {
        private readonly DiarnaContext _diarnaContext;
        public ReservedUnit2(DiarnaContext diarnaContext)
        {
            this._diarnaContext = diarnaContext;
        }
        public async Task<IEnumerable<TblReservation>> GetAllReservedUnits2()
        {
            try
            {
                return await _diarnaContext.TblReservations
                    .Include(n => n.RentUser)
                    .Include(n => n.Date)
                    .Include(n => n.Unit)
                    .Include(n => n.Unit.Building)
                    .Include(n => n.Unit.Building.Village).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //public async Task<IEnumerable<TblReservation>> GetAllReservedUnitsWithDetails2()
        //{
        //    try
        //    {
        //        return await _diarnaContext.TblReservations
        //            .Include(n => n.RentUser)
        //            .Include(n => n.Date)
        //            .Include(n => n.Unit)
        //            .Include(n => n.Unit.Building)
        //            .Include(n => n.Unit.Building.Village).ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}


        public async Task<TblReservation> GetReservedUnitById2(int unitId, int dateId)
        {
            try
            {
                return await _diarnaContext.TblReservations
                    .Include(n => n.RentUser)
                    .Include(n => n.Date)
                    .Include(n => n.Unit)
                    .Include(n => n.Unit.Building)
                    .Include(n => n.Unit.Building.Village)
                    .Where(n => n.UnitId == unitId && dateId == dateId)
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblReservation> AddReservedUnit2(TblReservation tblRentedUnit)
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

        public async Task<TblReservation> UpdateReservedUnit2(TblReservation tblRentedUnit)
        {
            try
            {
                _diarnaContext.Entry(tblRentedUnit).State = EntityState.Detached;
                await _diarnaContext.SaveChangesAsync();
                return tblRentedUnit;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteReservedUnit2(int unitId, int dateId)
        {
            try
            {
                var result = await GetReservedUnitById2(unitId, dateId);
                if (result != null)
                {
                    _diarnaContext.TblReservations.Remove((TblReservation)result);
                    await _diarnaContext.SaveChangesAsync();
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
