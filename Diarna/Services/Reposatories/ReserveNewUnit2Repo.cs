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
    public class ReserveNewUnit2Repo : IReserveNewUnit2
    {
        private readonly DiarnaContext _diarnaContext;
        public ReserveNewUnit2Repo(DiarnaContext diarnaContext)
        {
            this._diarnaContext = diarnaContext;
        }

        public async Task<IEnumerable<TblReservation>> GetAllReservedUnits2()
        {
            try
            {
                return await _diarnaContext.TblReservations
                    .Include(n => n.Date)
                    .Include(n => n.RentUser)
                    .Include(n => n.Unit)
                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        //public async Task<IEnumerable<TblReservation>> GetAllAvailableUnits2()
        //{
        //    try
        //    {
        //        return await _diarnaContext.TblReservations
        //            .Include(n => n.Date)
        //            .Include(n => n.RentUser)
        //            .Include(n => n.Unit)
        //            .ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}
        public async Task<IEnumerable<TblReservation>> GetUnitsByOneDate2(DateTime date)
        {
            try
            {
                var returned = await _diarnaContext.TblReservations
                    .Include(x => x.Unit)
                    .Include(x => x.RentUser)
                    .Include(x => x.Date)
                    //.Where(x => x.Date.StartDate <= date && x.Date.EndDate >= date)
                    .Where(x => x.Date.StartDate >= date && x.Date.EndDate <= date)
                    .Where(x => x.Date.StartDate >= DateTime.Now && x.Date.EndDate >= DateTime.Now)
                    .ToListAsync();
                return returned;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TblReservation>> GetAllReservedUnitsWithDate2(DateTime startDate, DateTime endDate)
        {
            try
            {
                return await _diarnaContext.TblReservations
                    .Include(x => x.Unit)
                    .Include(x => x.RentUser)
                    .Include(x => x.Date)
                    .Where(x => x.Date.StartDate == startDate && x.Date.EndDate == endDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<TblReservation>> GetAvailableDatesForUnit2(DateTime startDate, DateTime endDate)
        {
            try
            {
                return await _diarnaContext.TblReservations
                    .Include(x => x.Unit)
                    .Include(x => x.RentUser)
                    .Include(x => x.Date)
                    .Where(x => x.Date.StartDate != startDate && x.Date.EndDate != endDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<TblReservation>> GetAvailableDatesForUnit2(DateTime startDate, DateTime endDate, int unitId)
        {
            try
            {
                return await _diarnaContext.TblReservations
                    .Include(x => x.Unit)
                    .Include(x => x.RentUser)
                    .Include(x => x.Date)
                    .Where(x => x.UnitId == unitId && x.Date.StartDate == startDate && x.Date.EndDate == endDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<TblReservation>> GetAllAvailableDatesWithUnit2(int unitId)
        {
            try
            {
                return await _diarnaContext.TblReservations
                    .Include(x => x.Unit)
                    .Include(x => x.RentUser)
                    .Include(x => x.Date)
                    .Where(x => x.UnitId == unitId).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TblReservation>> GetAllReservedDatesWithUnit2(int unitId)
        {
            try
            {
                return await _diarnaContext.TblReservations
                    .Include(x => x.Unit)
                    .Include(x => x.RentUser)
                    .Include(x => x.Date)
                    .Where(x => x.UnitId == unitId).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
