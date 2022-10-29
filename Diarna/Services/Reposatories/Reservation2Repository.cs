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
    public class Reservation2Repository : IReservation2
    {
        private readonly DiarnaContext _diarnaContext;
        public Reservation2Repository(DiarnaContext diarnaContext)
        {
            this._diarnaContext = diarnaContext;
        }

        public async Task<IEnumerable<TblReservation>> GetAllReservations2()
        {
            return await _diarnaContext.TblReservations
                .Include(n=>n.Date).Include(n=>n.RentUser).Include(n=>n.Unit).ToListAsync();
        }

        public async Task<IEnumerable<TblReservation>> GetAllReservationsWithDate2(int dateId)
        {
            try
            {
                return await _diarnaContext.TblReservations
                    .Include(n => n.Date).Include(n => n.RentUser).Include(n => n.Unit)
                    .Where(n => n.DateId == dateId).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TblReservation>> GetAllReservationsWithUnit2(int unitId)
        {
            try
            {
                return await _diarnaContext.TblReservations
                    .Include(n => n.Date).Include(n => n.RentUser).Include(n => n.Unit)
                    .Where(n => n.UnitId == unitId).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblReservation> GetReservationByIdAndDate2(int unitId, int dateId)
        {
            try
            {
                return await _diarnaContext.TblReservations
                   .Include(n => n.Date).Include(n => n.RentUser).Include(n => n.Unit)
                    .Where(n => n.DateId == dateId && n.UnitId == unitId).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblReservation> AddReservation2(TblReservation tblReservation)
        {
            try
            {
                var result = await _diarnaContext.TblReservations.AddAsync(tblReservation);
                await _diarnaContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<TblReservation> UpdateReservation2(TblReservation tblReservation)
        {
            try
            {
                _diarnaContext.Entry(tblReservation).State = EntityState.Modified;
                await _diarnaContext.SaveChangesAsync();
                return tblReservation;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteReservation2(int unitId, int dateId)
        {
            try
            {
                var result = await GetReservationByIdAndDate2(unitId, dateId);
                if (result != null)
                {
                    _diarnaContext.TblReservations.Remove(result);
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

        public async Task<IEnumerable<TblReservation>> GetAllReservedUnits2()
        {
            return await _diarnaContext.TblReservations
                .Include(n => n.Date).Include(n => n.RentUser).Include(n => n.Unit).ToListAsync();
        }
    }
}
