using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IItem2
    {
        Task<IEnumerable<TblItem>> GetAllItems2();
        Task<TblItem> GetItemById2(int id);
        Task<TblItem> UpdateItem2(TblItem tblItem);
        Task<TblItem> AddItem2(TblItem tblItem);
        Task<bool> DeleteItem2(int id);
    }
}
