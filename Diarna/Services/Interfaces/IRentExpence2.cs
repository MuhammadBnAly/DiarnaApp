using System.Threading.Tasks;
using System.Collections.Generic;
using Diarna.Data.Domain;
using System;

namespace Diarna.Services.Interfaces
{
    public interface IRentExpence2
    {
        //Task<IEnumerable<TblRentExpense>> GetAllRentExpenses2();
        //Task<IEnumerable<TblRentExpense>> GetRentExpenseById2(int unitId, int? itemId);
        //Task<IEnumerable<TblRentExpense>> GetRentExpenseByUnitId2(int unitId);
        Task<IEnumerable<TblRentExpense>> GetAllRentExpensesWithDetails2();
        Task<TblRentExpense> GetRentExpenseWithDetailsById2(int unitId, int? itemId, DateTime date);
        Task<TblRentExpense> AddRentExpense2(TblRentExpense tblRentExpense);
        Task<TblRentExpense> UpdateRentExpense2(TblRentExpense tblRentExpense);
        Task<bool> DeleteRentExpense2(int unitId, int? itemId, DateTime date);
    }
}
