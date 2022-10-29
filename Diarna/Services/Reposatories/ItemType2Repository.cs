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
    public class ItemType2Repository : IItemType2
    {
        private readonly DiarnaContext _diarnaContext;
        public ItemType2Repository(DiarnaContext diarnaContext)
        {
            this._diarnaContext = diarnaContext;
        }

        public async Task<IEnumerable<TblItemType>> GetAllItemTypes2()
        {
            try
            {
                return await _diarnaContext.TblItemTypes.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblItemType> GetItemTypeById2(int id)
        {
            try
            {
                return await _diarnaContext.TblItemTypes.SingleOrDefaultAsync(n => n.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<TblItemType> AddItemType2(TblItemType tblItemType)
        {
            try
            {
                var result = await _diarnaContext.AddAsync(tblItemType);
                await _diarnaContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<TblItemType> UpdateItemType2(TblItemType tblItemType)
        {
            try
            {
                _diarnaContext.Entry(tblItemType).State = EntityState.Modified;
                await _diarnaContext.SaveChangesAsync();
                return tblItemType;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteItemType2(int id)
        {
            try
            {
                var result = await GetItemTypeById2(id);
                if (result == null)
                    return false;
                _diarnaContext.TblItemTypes.Remove(result);
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
