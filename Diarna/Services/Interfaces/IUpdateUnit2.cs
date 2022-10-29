using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IUpdateUnit2
    {
        Task<TblUnit> getUpdateUnitById2(int id);
        Task<TblUnit> EditUpdateUnit2(TblUnit unit);
    }
}
