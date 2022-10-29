using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IRentedUnit2
    {
        Task<IEnumerable<TblRentedUnit>> GetAllRentedUnits2();
        Task<TblRentedUnit> GetRentedUnitById2(int id);
        Task<TblRentedUnit> AddRentedUnit2(TblRentedUnit tblRentedUnit);
        Task<TblRentedUnit> UpdateRentedUnit2(TblRentedUnit tblRentedUnit);
        Task<bool> DeleteRentedUnit2(int id);

        Task<IEnumerable<TblRentedUnit>> GetAllRentedUnitsWithDetails2();

    }
}
