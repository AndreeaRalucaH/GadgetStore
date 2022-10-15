using ProiectAfaceriElectronice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectAfaceriElectronice.Repositories
{
    public interface IComenzi
    {
        Task<IEnumerable<Comenzi>> Get();
        Task<Comenzi> GetByDen(string den);
        Task<Comenzi> GetById(int id);
        Task<Comenzi> Create(Comenzi com);
        Task Update(Comenzi com);
        Task Delete(int id);
    }
}
