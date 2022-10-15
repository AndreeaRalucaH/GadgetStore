using ProiectAfaceriElectronice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProiectAfaceriElectronice.Repositories
{
    public class ComenziRepo : IComenzi
    {

        private readonly postgresContext _postgresContext;

        public ComenziRepo(postgresContext context)
        {
            _postgresContext = context;
        }
        public async Task<Comenzi> Create(Comenzi com)
        {
            _postgresContext.Comenzis.Add(com);
            await _postgresContext.SaveChangesAsync();

            return com;
        }

        public async Task Delete(int id)
        {
            var comToDelete = await _postgresContext.Comenzis.FindAsync(id);
            _postgresContext.Comenzis.Remove(comToDelete);
            await _postgresContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comenzi>> Get()
        {
            return await _postgresContext.Comenzis.OrderBy(x => x.Idcomanda).ToListAsync();
        }

        public Task<Comenzi> GetByDen(string den)
        {
            throw new NotImplementedException();
        }

        public async Task<Comenzi> GetById(int id)
        {
            return await _postgresContext.Comenzis.FindAsync(id);
        }

        public async Task Update(Comenzi com)
        {
            _postgresContext.Entry(com).State = EntityState.Modified;
            await _postgresContext.SaveChangesAsync();
        }
    }
}
