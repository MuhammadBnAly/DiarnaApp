using Diarna.Data.Domain;
using Diarna.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Diarna.Data;
using System;

namespace Diarna.Services.Reposatories
{
    public class RentUser2Repository : IRentUser2
    {
        private readonly DiarnaContext _context;
        public RentUser2Repository(DiarnaContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<TblRentUser>> GetAllRentUsers2()
        {
            try
            {
                return await _context.TblRentUsers.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblRentUser> GetRentUserById2(int id)
        {
            try
            {
                return await _context.TblRentUsers.SingleOrDefaultAsync(n => n.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblRentUser> GetRentUserByMobile2(string mobile)
        {
            try
            {
                return await _context.TblRentUsers.SingleOrDefaultAsync(n => n.Mobile == mobile);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<TblRentUser> AddRentUser2(TblRentUser user)
        {
            try
            {
                var result = await _context.TblRentUsers.AddAsync(user);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblRentUser> UpdateRentUser2(TblRentUser user)
        {
            try
            {
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public async Task<TblRentUser> UpdateRentUserById2(TblRentUser user)
        //{
        //    try
        //    {
        //        _context.Entry(user).State = EntityState.Modified;
        //        await _context.SaveChangesAsync();
        //        return user;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        //public async Task<TblRentUser> UpdateRentUserByMobile2(TblRentUser user)
        //{
        //    try
        //    {
        //        _context.Entry(user).State = EntityState.Modified;
        //        await _context.SaveChangesAsync();
        //        return user;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        public async Task<bool> DeleteRentUserById2(int id)
        {
            try
            {
                var result = await GetRentUserById2(id);
                if (result != null)
                {
                    _context.TblRentUsers.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteRentUserByMobile2(string mobile)
        {
            try
            {
                var result = await GetRentUserByMobile2(mobile);
                if (result != null)
                {
                    _context.TblRentUsers.Remove(result);
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
    }
}
