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
    public class ExamRepository : IExamRepository
    {
        private StudentDbContext _db;
        public ExamRepository(StudentDbContext context)
        {
            this._db = context;
        }
        public async Task AddAsync(Exam entity)
        {
            await _db.Exams.AddAsync(entity);
        }

        public void Delete(Exam entity)
        {
            var index = _db.Exams.Find(entity);
            if (index != null)
            {
                _db.Exams.Remove(entity);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var en = await _db.Exams.SingleOrDefaultAsync(p => p.Id == id);
            if (en != null)
            {
                _db.Exams.Remove(en);
            }
        }

        public IQueryable<Exam> FindAll()
        {
            return _db.Exams.AsQueryable();
        }

        public IQueryable<Exam> GetAllWithDetails()
        {
            return _db.Exams;
        }

        public async Task<Exam> GetByIdAsync(int id)
        {
            var sources = await _db.Exams
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            return sources;
        }

        public async Task<Exam> GetByIdWithDetailsAsync(int id)
        {
            return await _db.Exams
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(Exam entity)
        {
            _db.Exams.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
    }
}
