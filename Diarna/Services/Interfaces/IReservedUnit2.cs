using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IReservedUnit2
    {
        Task<IEnumerable<TblReservation>> GetAllReservedUnits2();
        Task<TblReservation> GetReservedUnitById2(int unitId, int dateId);
        Task<TblReservation> AddReservedUnit2(TblReservation tblReservation);
        Task<TblReservation> UpdateReservedUnit2(TblReservation tblReservation);
        Task<bool> DeleteReservedUnit2(int unitId, int dateId);

        //Task<IEnumerable<TblReservation>> GetAllReservedUnitsWithDetails2();
    }
}
