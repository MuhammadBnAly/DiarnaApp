using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;
namespace Diarna.Services.Interfaces
{
    public interface ITenderShareHolder2
    {
        Task<IEnumerable<TblTenderShare>> GetAllTenderShareHolders2();
        Task<TblTenderShare> GetTenderShareHolderById2(int id);
        Task<TblTenderShare> UpdateTenderShareHolder2(TblItem tblItem);
        Task<TblTenderShare> AddTenderShareHolder2(TblItem tblItem);
        Task<bool> DeleteTenderShareHolder2(int id);
    }
}
