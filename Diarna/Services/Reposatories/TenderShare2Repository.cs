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
    public class TenderShare2Repository : ITenderShare2
    {
        private readonly DiarnaContext _diarnaContext;
        public TenderShare2Repository(DiarnaContext diarnaContext)
        {
            this._diarnaContext = diarnaContext;
        } 
        public async Task<TblTenderShare> AddTenderShare(TblTenderShare tblTenderShare)
        {
            try
            {
                var result = await _diarnaContext.AddAsync(tblTenderShare);
                await _diarnaContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteTenderShare(int tenderId, int shareId, int year)
        {
            try
            {
                var result = await GetTenderShareById(tenderId, shareId, year);
                if (result == null)
                    return false;
                _diarnaContext.TblTenderShares.Remove(result);
                await _diarnaContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TblTenderShare>> GetAllTenderShares()
        {
            try
            {
                return await _diarnaContext.TblTenderShares.Include(n => n.Shares)
                    .Include(n => n.Tender).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblTenderShare> GetTenderShareById(int tenderId, int shareId, int year)
        {
            try
            {
                return await _diarnaContext.TblTenderShares
                    .Include(n => n.Shares).Include(n => n.Tender)
                    .Where(n => n.SharesId == shareId)
                    .Where(n => n.TenderId == tenderId)
                    .Where(n => n.Year == year)
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblTenderShare> UpdateTenderShare(TblTenderShare tblTenderShare)
        {
            try
            {
                _diarnaContext.Entry(tblTenderShare).State = EntityState.Modified;
                await _diarnaContext.SaveChangesAsync();
                return tblTenderShare;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
