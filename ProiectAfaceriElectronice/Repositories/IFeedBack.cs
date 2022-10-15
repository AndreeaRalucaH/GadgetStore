using ProiectAfaceriElectronice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectAfaceriElectronice.Repositories
{
    public interface IFeedBack
    {
        Task<IEnumerable<Feedbackproduse>> Get();
        Task<Feedbackproduse> GetByDen(string den);
        Task<Feedbackproduse> GetById(int id);
        Task<Feedbackproduse> Create(Feedbackproduse feed);
        Task Update(Feedbackproduse feed);
        Task Delete(int id);
    }
}
