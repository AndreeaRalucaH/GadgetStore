using ProiectAfaceriElectronice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProiectAfaceriElectronice.Repositories
{
    public class FeedBackRepo : IFeedBack
    {

        private readonly postgresContext _postgresContext;

        public FeedBackRepo(postgresContext context)
        {
            _postgresContext = context;
        }
        public async Task<Feedbackproduse> Create(Feedbackproduse feed)
        {
            _postgresContext.Feedbackproduses.Add(feed);
            await _postgresContext.SaveChangesAsync();

            return feed;
        }

        public async Task Delete(int id)
        {
            var feedToDelete = await _postgresContext.Feedbackproduses.FindAsync(id);
            _postgresContext.Feedbackproduses.Remove(feedToDelete);
            await _postgresContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Feedbackproduse>> Get()
        {
            return await _postgresContext.Feedbackproduses.OrderBy(x => x.Idfeedback).ToListAsync();
        }

        public async Task<Feedbackproduse> GetByDen(string den)
        {
            return await _postgresContext.Feedbackproduses.Where(x => x.Client.Equals(den)).SingleOrDefaultAsync();
        }

        public async Task<Feedbackproduse> GetById(int id)
        {
            return await _postgresContext.Feedbackproduses.FindAsync(id);
        }

        public async Task Update(Feedbackproduse feed)
        {
            _postgresContext.Entry(feed).State = EntityState.Modified;
            await _postgresContext.SaveChangesAsync();
        }
    }
}
