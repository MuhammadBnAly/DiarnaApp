using Diarna.Data.Domain;
using Diarna.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Diarna.Data;
using System;


namespace Diarna.Services.Reposatories
{
    public class Share2Repository : IShares2
    {
        private readonly DiarnaContext _context;
        public Share2Repository(DiarnaContext diarnaContext)
        {
            _context = diarnaContext;
        }
        //public async Task<IEnumerable<TblShare>> GetAllShares2()
        //{
        //    try
        //    {
        //        return await _context.TblShares.ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public async Task<IEnumerable<TblShare>> GetAllSharesWithDetails2()
        {
            try
            {
                return await _context.TblShares.Include(n => n.UserShares).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //public async Task<TblShare> GetShareById2(int id)
        //{
        //    try
        //    {
        //        return await _context.TblShares.SingleOrDefaultAsync(n => n.Id == id);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public async Task<TblShare> GetShareWithDetailById2(int id)
        {
            try
            {
                return await _context.TblShares.Include(n => n.UserShares).SingleOrDefaultAsync(n => n.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblShare> AddShare2(TblShare tblShare)
        {
            try
            {
                var result = await _context.TblShares.AddAsync(tblShare);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<TblShare> UpdateShare2(TblShare tblShare)
        {
            try
            {
                _context.Entry(tblShare).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return tblShare;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteShare2(int id)
        {
            try
            {
                var result = await GetShareWithDetailById2(id);
                if (result != null)
                {
                    _context.TblShares.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TblShare> GetShareWithDetailByName2(string name)
        {
            try
            {
                // اسم السهم
                return await _context.TblShares.Include(n => n.UserShares).SingleOrDefaultAsync(n => n.Name == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
