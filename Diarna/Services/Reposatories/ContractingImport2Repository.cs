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
    public class ContractingImport2Repository : IContractingImport2
    {
        private readonly DiarnaContext _diarnaContext;
        public ContractingImport2Repository(DiarnaContext diarnaContext)
        {
            _diarnaContext = diarnaContext;
        }

        public async Task<IEnumerable<TblContractingImport>> GetAllContractingImports2()
        {
            try
            {
                return await _diarnaContext.TblContractingImports.Include(n => n.Item)
                    .Include(n => n.Tender).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TblContractingImport> GetContractingImportById2(int id)
        {
            try
            {
                return await _diarnaContext.TblContractingImports.Include(n => n.Item)
                    .Include(n => n.Tender).Where(n => n.Id == id).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<TblContractingImport> AddContractingImport(TblContractingImport tblContractingImport)
        {
            try
            {
                var result = await _diarnaContext.AddAsync(tblContractingImport);
                await _diarnaContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<TblContractingImport> UpdateContractingImport(TblContractingImport tblContractingImport)
        {
            try
            {
                _diarnaContext.Entry(tblContractingImport).State = EntityState.Modified;
                await _diarnaContext.SaveChangesAsync();
                return tblContractingImport;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteContractingImport(int id)
        {
            try
            {
                var result = await GetContractingImportById2(id);
                if (result == null)
                    return false;
                _diarnaContext.TblContractingImports.Remove(result);
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
