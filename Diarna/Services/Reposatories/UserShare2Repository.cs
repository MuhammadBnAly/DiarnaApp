using Diarna.Data.Domain;
using Diarna.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Diarna.Data;
using System;
namespace Diarna.Services.Reposatories
{
    public class UserShare2Repository : IUserShare2
    {
        private readonly DiarnaContext _context;
        public UserShare2Repository(DiarnaContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<TblUserShare>> GetAllUserShare2()
        {
            try
            {
                return await _context.TblUserShares.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblUserShare> GetUserShareById2(int id)
        {
            try
            {
                return await _context.TblUserShares.SingleOrDefaultAsync(n => n.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<TblUserShare> AddUserShare2(TblUserShare user)
        {
            try
            {
                var result = await _context.TblUserShares.AddAsync(user);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<TblUserShare> UpdateUserShare2(TblUserShare user)
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
        public async Task<bool> DeleteUserShare2(int id)
        {
            try
            {
                var result = await GetUserShareById2(id);
                if (result != null)
                {
                    _context.TblUserShares.Remove(result);
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
