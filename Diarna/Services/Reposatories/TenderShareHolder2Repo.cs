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
    public class TenderShareHolder2Repo : ITenderShareHolder2
    {
        private readonly DiarnaContext _context;
        public TenderShareHolder2Repo(DiarnaContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<TblTenderShare>> GetAllTenderShareHolders2()
        {

            return await _context.TblTenderShares.
                Include(n => n.Shares.UserShares)
                .Include(n => n.Shares)
                .Include(n => n.Tender).ToListAsync();


            //var query = from tendershare in TblTenderShare
            //            join share in _context.TblShare 
            //            on tendershare.
            //            where tendershare.SharesId == share.Id
            //return await _context.TblTenderShares.Join(x => x.).ToListAsync();
        }

        public Task<TblTenderShare> GetTenderShareHolderById2(int id)
        {
            throw new NotImplementedException();
        }
        public Task<TblTenderShare> AddTenderShareHolder2(TblItem tblItem)
        {
            throw new NotImplementedException();
        }
        public Task<TblTenderShare> UpdateTenderShareHolder2(TblItem tblItem)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteTenderShareHolder2(int id)
        {
            throw new NotImplementedException();
        }



    }
}
