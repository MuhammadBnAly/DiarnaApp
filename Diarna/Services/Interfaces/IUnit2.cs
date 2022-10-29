using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IUnit2
    {
        Task<IEnumerable<TblUnit>> GetAllUnits2();
        Task<TblUnit> GetUnitById2(int id);
        Task<TblUnit> AddUnit2(TblUnit tblUnit);
        Task<TblUnit> UpdateUnit2(TblUnit tblUnit);
        Task<bool> DeleteUnit2(int id);
    }
}
