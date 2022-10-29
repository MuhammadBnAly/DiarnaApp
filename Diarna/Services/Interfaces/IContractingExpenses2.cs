using Diarna.Data.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diarna.Services.Interfaces
{
    public interface IContractingExpenses2
    {
        Task<IEnumerable<TblContractingExpnse>> GetAllContractingExpenses2();
        Task<TblContractingExpnse> GetContractingExpensesById2(int id);
        Task<TblContractingExpnse> AddContractingExpenses(TblContractingExpnse tblContractingExpnse);
        Task<TblContractingExpnse> UpdateContractingExpenses(TblContractingExpnse tblContractingExpnse);

        Task<bool> DeleteContractingExpenses(int id);

    }
}
