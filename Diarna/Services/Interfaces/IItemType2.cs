using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IItemType2
    {
        Task<IEnumerable<TblItemType>> GetAllItemTypes2();
        Task<TblItemType> GetItemTypeById2(int id);
        Task<TblItemType> AddItemType2(TblItemType tblItemType);
        Task<TblItemType> UpdateItemType2(TblItemType tblItemType);
        Task<bool> DeleteItemType2(int id);
    }
}
