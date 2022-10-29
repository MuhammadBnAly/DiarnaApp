using Microsoft.EntityFrameworkCore;
using Diarna.Data;
using Diarna.Data.Domain;
using Diarna.Services.Interfaces;
using System.Threading.Tasks;
using System;

namespace Diarna.Services.Reposatories
{
    public class UpdateUnit2Repository : IUpdateUnit2
    {
        private readonly DiarnaContext _diarnaContext;
        public UpdateUnit2Repository(DiarnaContext diarnaContext)
        {
            this._diarnaContext = diarnaContext;
        }

        public async Task<TblUnit> getUpdateUnitById2(int id)
        {
            try
            {
                return await _diarnaContext.TblUnits.SingleOrDefaultAsync(t => t.Id == id);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TblUnit> EditUpdateUnit2(TblUnit unit)
        {
            try
            {
                _diarnaContext.Entry(unit).State = EntityState.Modified;
                await _diarnaContext.SaveChangesAsync();
                return unit;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
