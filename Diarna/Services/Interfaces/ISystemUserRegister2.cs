using Diarna.Data.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Diarna.Services.Interfaces
{
    public interface ISystemUserRegister2
    {
        Task<IEnumerable<TblSystemUser>> GetAllSystemUsers2();
        Task<TblSystemUser> GetSystemUserById2(int id);
        Task<TblSystemUser> AddSystemUser2(TblSystemUser user);
        Task<TblSystemUser> UpdateSystemUser2(TblSystemUser user);
        Task<bool> DeleteSystemUser2(int id);

    }
}
