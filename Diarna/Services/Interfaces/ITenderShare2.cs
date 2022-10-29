using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface ITenderShare2
    {
        Task<IEnumerable<TblTenderShare>> GetAllTenderShares();
        Task<TblTenderShare> GetTenderShareById(int tenderId, int shareId, int year);
        Task<TblTenderShare> AddTenderShare(TblTenderShare tblTenderShare);
        Task<TblTenderShare> UpdateTenderShare(TblTenderShare tblTenderShare);

        Task<bool> DeleteTenderShare(int tenderId, int shareId, int year);

    }
}
