using ProiectAfaceriElectronice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProiectAfaceriElectronice.Repositories
{
    public class ProduseRepo : IProdus
    {
        private readonly postgresContext _postgresContext;

        public ProduseRepo(postgresContext context)
        {
            _postgresContext = context;
        }

        public async Task<Produse> Create(Produse prod)
        {
            _postgresContext.Produses.Add(prod);
            await _postgresContext.SaveChangesAsync();

            return prod;
        }

        public async Task Delete(int id)
        {
            var prodToDelete = await _postgresContext.Produses.FindAsync(id);
            _postgresContext.Produses.Remove(prodToDelete);
            await _postgresContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Produse>> Get()
        {
            return await _postgresContext.Produses.OrderBy(x => x.Idprodus).ToListAsync();
        }

        public async Task<Produse> GetByDen(string den)
        {
            return await _postgresContext.Produses.Where(x => x.Denumire.Equals(den)).SingleOrDefaultAsync();
        }

        public async Task<Produse> GetById(int id)
        {
            return await _postgresContext.Produses.FindAsync(id);
        }

        public async Task Update(Produse prod)
        {
            _postgresContext.Entry(prod).State = EntityState.Modified;
            await _postgresContext.SaveChangesAsync();
        }
    }
}
