using ProiectAfaceriElectronice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProiectAfaceriElectronice.Repositories
{
    public class DetaliiComenziRepo : IDetaliiComenzi
    {
        private readonly postgresContext _postgresContext;

        public DetaliiComenziRepo(postgresContext context)
        {
            _postgresContext = context;
        }
        public async Task<Detaliicomenzi> Create(Detaliicomenzi com)
        {
            _postgresContext.Detaliicomenzis.Add(com);
            await _postgresContext.SaveChangesAsync();

            return com;
        }

        public async Task Delete(int id)
        {
            var detalToDelete = await _postgresContext.Detaliicomenzis.FindAsync(id);
            _postgresContext.Detaliicomenzis.Remove(detalToDelete);
            await _postgresContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Detaliicomenzi>> Get()
        {
            return await _postgresContext.Detaliicomenzis.OrderBy(x => x.Idcomanda).ToListAsync();
        }

        public async Task<Detaliicomenzi> GetByDen(string den)
        {
            return await _postgresContext.Detaliicomenzis.Where(x => x.Numeutilizator.Equals(den)).SingleOrDefaultAsync();
        }

        public async Task<Detaliicomenzi> GetById(int id)
        {
            return await _postgresContext.Detaliicomenzis.FindAsync(id);
        }

        public async Task Update(Detaliicomenzi com)
        {
            _postgresContext.Entry(com).State = EntityState.Modified;
            await _postgresContext.SaveChangesAsync();
        }
    }
}
