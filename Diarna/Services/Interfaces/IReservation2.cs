using System.Threading.Tasks;
using System.Collections.Generic;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IReservation2
    {
        Task<IEnumerable<TblReservation>> GetAllReservations2();
        Task<IEnumerable<TblReservation>> GetAllReservedUnits2();

        Task<IEnumerable<TblReservation>> GetAllReservationsWithDate2(int dateId);
        Task<IEnumerable<TblReservation>> GetAllReservationsWithUnit2(int unitId);
        Task<TblReservation> GetReservationByIdAndDate2(int unitId, int dateId);
        Task<TblReservation> AddReservation2(TblReservation tblReservation);
        Task<TblReservation> UpdateReservation2(TblReservation tblReservation);
        Task<bool> DeleteReservation2(int unitId, int dateId);


    }
}
