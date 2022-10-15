using ProiectAfaceriElectronice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectAfaceriElectronice.Repositories
{
    public interface IProdus
    {
        Task<IEnumerable<Produse>> Get();
        Task<Produse> GetByDen(string den);
        Task<Produse> GetById(int id);
        Task<Produse> Create(Produse prod);
        Task Update(Produse prod);
        Task Delete(int id);



    }
}
