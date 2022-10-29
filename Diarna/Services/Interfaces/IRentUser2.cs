using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IRentUser2
    {
        Task<IEnumerable<TblRentUser>> GetAllRentUsers2();
        Task<TblRentUser> GetRentUserById2(int id);
        Task<TblRentUser> GetRentUserByMobile2(string mobile);
        Task<TblRentUser> AddRentUser2(TblRentUser user);
        Task<TblRentUser> UpdateRentUser2(TblRentUser user);
        //Task<TblRentUser> UpdateRentUserById2(TblRentUser user);
        //Task<TblRentUser> UpdateRentUserByMobile2(TblRentUser user);
        Task<bool> DeleteRentUserById2(int id);
        Task<bool> DeleteRentUserByMobile2(string mobile);
    }
}
