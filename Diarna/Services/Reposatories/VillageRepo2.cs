using Diarna.Data.Domain;
using Diarna.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Diarna.Services.Reposatories
{
    public class VillageRepo2 : IVillage2
    {
        private readonly DiarnaContext _diarnaContext;
        public VillageRepo2(DiarnaContext diarnaContext)
        {
            _diarnaContext = diarnaContext;
        }

        public async Task<IEnumerable<TblVillage>> GetAllVillages2()
        {
            return await _diarnaContext.TblVillages.ToListAsync();
        }

        public async Task<TblVillage> GetVillageById2(int id)
        {
            return await _diarnaContext.TblVillages.SingleOrDefaultAsync(n => n.Id == id);
        }
        public async Task<TblVillage> GetVillageByName2(string name)
        {
            return await _diarnaContext.TblVillages.SingleOrDefaultAsync(n => n.Name == name);
        }

        public async Task<TblVillage> AddVillage2(TblVillage tblVillage)
        {
            try
            {
                var result = await _diarnaContext.TblVillages.AddAsync(tblVillage);
                await _diarnaContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TblVillage> UpdateVillage2(TblVillage tblVillage)
        {
            try
            {
                _diarnaContext.Entry(tblVillage).State = EntityState.Modified;
                await _diarnaContext.SaveChangesAsync();
                return tblVillage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteVillageById2(int id)
        {
            var village = await GetVillageById2(id);
            if (village == null)
                return false;
            _diarnaContext.TblVillages.Remove(village);
            await _diarnaContext.SaveChangesAsync();
            return true;
        }


    }
}
