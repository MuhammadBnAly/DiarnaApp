using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IBuilding2
    {
        Task<IEnumerable<TblBuilding>> GetAllBuildings2();
        Task<TblBuilding> GetBuildingsById2(int id);
        Task<TblBuilding> GetBuildingsByName2(string name);
        Task<TblBuilding> AddBuilding2(TblBuilding tblBuilding);
        Task<TblBuilding> UpdateBuilding2(TblBuilding tblBuilding);
        Task<bool> DeleteBuilding2(int id);
    }
}
