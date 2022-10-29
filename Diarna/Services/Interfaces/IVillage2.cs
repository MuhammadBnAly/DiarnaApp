using Diarna.Data.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diarna.Services.Interfaces
{
    public interface IVillage2
    {
        Task<IEnumerable<TblVillage>> GetAllVillages2();
        Task<TblVillage> GetVillageById2(int id);
        Task<TblVillage> GetVillageByName2(string name);

        Task<TblVillage> AddVillage2(TblVillage tblVillage);
        Task<TblVillage> UpdateVillage2(TblVillage tblVillage);
        Task<bool> DeleteVillageById2(int id);
    }
}
