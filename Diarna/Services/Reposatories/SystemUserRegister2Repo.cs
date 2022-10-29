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
    public class SystemUserRegister2Repo : ISystemUserRegister2
    {
        private readonly DiarnaContext diarnaContext;
        public SystemUserRegister2Repo(DiarnaContext diarnaContext)
        {
            this.diarnaContext = diarnaContext;
        }


        public async Task<IEnumerable<TblSystemUser>> GetAllSystemUsers2()
        {
            return await diarnaContext.TblSystemUsers.ToListAsync();
        }

        public async Task<TblSystemUser> GetSystemUserById2(int id)
        {
            return await diarnaContext.TblSystemUsers.SingleOrDefaultAsync(n => n.Id == id);
        }
        public async Task<TblSystemUser> AddSystemUser2(TblSystemUser user)
        {
            var result = await diarnaContext.AddAsync(user);
            await diarnaContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TblSystemUser> UpdateSystemUser2(TblSystemUser user)
        {
            diarnaContext.Entry(user).State = EntityState.Modified;
            await diarnaContext.SaveChangesAsync();
            return user;
        }
        public async Task<bool> DeleteSystemUser2(int id)
        {
            var result = await GetSystemUserById2(id);
            if (result != null)
            {
                diarnaContext.TblSystemUsers.Remove(result);
                await diarnaContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
