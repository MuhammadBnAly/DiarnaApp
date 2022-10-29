using System.Threading.Tasks;
using System.Collections.Generic;
using Diarna.Data.Domain;
using System;
namespace Diarna.Services.Interfaces
{
    public interface IReserveNewUnit2
    {
        Task<IEnumerable<TblReservation>> GetAllReservedUnits2(); // simp dto
        //Task<IEnumerable<TblReservation>> GetAllAvailableUnits2(); // simo dto
        Task<IEnumerable<TblReservation>> GetUnitsByOneDate2(DateTime date); // dto
        Task<IEnumerable<TblReservation>> GetAllReservedUnitsWithDate2(DateTime startDate, DateTime endDate); // units
        Task<IEnumerable<TblReservation>> GetAvailableDatesForUnit2(DateTime startDate, DateTime endDate); // units
        Task<IEnumerable<TblReservation>> GetAvailableDatesForUnit2(DateTime startDate, DateTime endDate, int unitId); // avail
        Task<IEnumerable<TblReservation>> GetAllReservedDatesWithUnit2(int unitId); // avail dates
        Task<IEnumerable<TblReservation>> GetAllAvailableDatesWithUnit2(int unitId); // avail dates


        //Task<IEnumerable<TblReservation>> GetBusyDatesForUnit2(DateTime startDate, DateTime endDate);
        //Task<IEnumerable<TblReservation>> GetBusyDatesForUnit(DateTime startDate, DateTime endDate, int unitId);

    }
}
