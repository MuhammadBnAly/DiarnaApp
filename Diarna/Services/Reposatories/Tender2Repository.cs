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
    public class Tender2Repository : ITender2
    {
        private readonly DiarnaContext _diarnaContext;
        public Tender2Repository(DiarnaContext diarnaContext)
        {
            _diarnaContext = diarnaContext;
        }

        public async Task<TblTender> AddTender(TblTender tblTender)
        {
            try
            {
                var result = await _diarnaContext.AddAsync(tblTender);
                await _diarnaContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteTender(int id)
        {
            try
            {
                var result = await GetTenderById(id);
                if (result == null)
                    return false;
                _diarnaContext.TblTenders.Remove(result);
                await _diarnaContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TblTender>> GetAllTenders()
        {
            try
            {
                return await _diarnaContext.TblTenders.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblTender> GetTenderById(int id)
        {
            try
            {
                return await _diarnaContext.TblTenders.SingleOrDefaultAsync(n => n.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblTender> UpdateTender(TblTender tblTender)
        {
            try
            {
                _diarnaContext.Entry(tblTender).State = EntityState.Modified;
                await _diarnaContext.SaveChangesAsync();
                return tblTender;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
