using Diarna.Data.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diarna.Services.Interfaces
{
    public interface IShares2
    {
        //Task<IEnumerable<TblShare>> GetAllShares2();
        Task<IEnumerable<TblShare>> GetAllSharesWithDetails2();

        //Task<TblShare> GetShareById2(int id);
        Task<TblShare> GetShareWithDetailById2(int id);
        Task<TblShare> GetShareWithDetailByName2(string name);
        Task<TblShare> AddShare2(TblShare tblShare);
        Task<TblShare> UpdateShare2(TblShare tblShare);
        Task<bool> DeleteShare2(int id);

    }
}
