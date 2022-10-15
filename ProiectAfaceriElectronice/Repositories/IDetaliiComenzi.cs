using ProiectAfaceriElectronice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectAfaceriElectronice.Repositories
{
    public interface IDetaliiComenzi
    {
        Task<IEnumerable<Detaliicomenzi>> Get();
        Task<Detaliicomenzi> GetByDen(string den);
        Task<Detaliicomenzi> GetById(int id);
        Task<Detaliicomenzi> Create(Detaliicomenzi com);
        Task Update(Detaliicomenzi com);
        Task Delete(int id);
    }
}
