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
    public class Item2Repository : IItem2
    {
        private readonly DiarnaContext _diarnaContext;
        public Item2Repository(DiarnaContext diarnaContext)
        {
            this._diarnaContext = diarnaContext;
        }
        public async Task<IEnumerable<TblItem>> GetAllItems2()
        {
            try
            {
                return await _diarnaContext.TblItems.Include(n => n.Itemtype).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblItem> GetItemById2(int id)
        {
            try
            {
                return await _diarnaContext.TblItems.Include(n => n.Itemtype).SingleOrDefaultAsync(n => n.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<TblItem> AddItem2(TblItem tblItem)
        {
            try
            {
                var result = await _diarnaContext.AddAsync(tblItem);
                await _diarnaContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<TblItem> UpdateItem2(TblItem tblItem)
        {
            try
            {
                _diarnaContext.Entry(tblItem).State = EntityState.Modified;
                await _diarnaContext.SaveChangesAsync();
                return tblItem;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteItem2(int id)
        {
            try
            {
                var result = await GetItemById2(id);
                if (result == null)
                    return false;
                _diarnaContext.TblItems.Remove(result);
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
