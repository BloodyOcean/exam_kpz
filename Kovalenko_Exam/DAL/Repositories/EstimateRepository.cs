using DAL.Enitites;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EstimateRepository : IEstimateRepository
    {
        private StudentDbContext _db;
        public EstimateRepository(StudentDbContext context)
        {
            this._db = context;
        }
        public async Task AddAsync(Estimate entity)
        {
            await _db.Estimates.AddAsync(entity);
        }

        public void Delete(Estimate entity)
        {
            var index = _db.Estimates.Find(entity);
            if (index != null)
            {
                _db.Estimates.Remove(entity);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var en = await _db.Estimates.SingleOrDefaultAsync(p => p.Id == id);
            if (en != null)
            {
                _db.Estimates.Remove(en);
            }
        }

        public IQueryable<Estimate> FindAll()
        {
            return _db.Estimates.AsQueryable();
        }

        public IQueryable<Estimate> GetAllWithDetails()
        {
            return _db.Estimates;
        }

        public async Task<Estimate> GetByIdAsync(int id)
        {
            var sources = await _db.Estimates
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            return sources;
        }

        public async Task<Estimate> GetByIdWithDetailsAsync(int id)
        {
            return await _db.Estimates
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(Estimate entity)
        {
            _db.Estimates.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
    }
}
