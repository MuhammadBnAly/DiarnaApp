using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;
namespace Diarna.Services.Interfaces
{
    public interface IUserShare2
    {
        Task<IEnumerable<TblUserShare>> GetAllUserShare2();
        Task<TblUserShare> GetUserShareById2(int id);
        Task<TblUserShare> AddUserShare2(TblUserShare user);
        Task<TblUserShare> UpdateUserShare2(TblUserShare user);
        Task<bool> DeleteUserShare2(int id);
    }
}
