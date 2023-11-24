using Sibers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Core.Repositories.Base
{
    public class SibersRepository<T> : ISibersRepository<T> where T : class
    {
        private protected readonly SibersDbContext _db;
        public SibersRepository(SibersDbContext db)
        {
            _db=db;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            _db.Remove(id);
            await _db.SaveChangesAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _db.FindAsync<T>(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
