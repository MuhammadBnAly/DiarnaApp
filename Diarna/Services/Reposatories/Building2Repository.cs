using Diarna.Services.Interfaces;
using Diarna.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Diarna.Services.Reposatories
{
    public class Building2Repository : IBuilding2
    {
        private readonly DiarnaContext _diarnaContext;
        public Building2Repository(DiarnaContext diarnaContext)
        {
            _diarnaContext = diarnaContext;
        }

        public async Task<IEnumerable<TblBuilding>> GetAllBuildings2()
        {
            try
            {
                return await _diarnaContext.TblBuildings.Include(n => n.Village)
                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblBuilding> GetBuildingsById2(int id)
        {
            try
            {
                return await _diarnaContext.TblBuildings.Include(n => n.Village)
                    .SingleOrDefaultAsync(n => n.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblBuilding> GetBuildingsByName2(string name)
        {
            try
            {
                return await _diarnaContext.TblBuildings.Include(n => n.Village)
                    .SingleOrDefaultAsync(n => n.Name == name);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<TblBuilding> AddBuilding2(TblBuilding tblBuilding)
        {
            try
            {
                var result = await _diarnaContext.AddAsync(tblBuilding);
                await _diarnaContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<TblBuilding> UpdateBuilding2(TblBuilding tblBuilding)
        {
            try
            {
                _diarnaContext.Entry(tblBuilding).State = EntityState.Modified;
                await _diarnaContext.SaveChangesAsync();
                return tblBuilding;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteBuilding2(int id)
        {
            try
            {
                var result = await GetBuildingsById2(id);
                if (result == null)
                    return false;
                _diarnaContext.TblBuildings.Remove(result);
                await _diarnaContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

       


    }
}
