using Diarna.Data.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diarna.Services.Interfaces
{
    public interface ITender2
    {
        Task<IEnumerable<TblTender>> GetAllTenders();
        Task<TblTender> GetTenderById(int id);
        Task<TblTender> AddTender(TblTender tblTender);
        Task<TblTender> UpdateTender(TblTender tblTender);
        Task<bool> DeleteTender(int id);
    }
}
