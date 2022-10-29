using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Diarna.Data.Domain;

namespace Diarna.Services.Interfaces
{
    public interface IContractingImport2
    {
        Task<IEnumerable<TblContractingImport>> GetAllContractingImports2();
        Task<TblContractingImport> GetContractingImportById2(int id);
        Task<TblContractingImport> AddContractingImport(TblContractingImport tblContractingImport);
        Task<TblContractingImport> UpdateContractingImport(TblContractingImport tblContractingImport);

        Task<bool> DeleteContractingImport(int id);
    }
}
