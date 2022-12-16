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
    public class StudentRepository : IStudentRepository
    {
        private StudentDbContext _db;
        public StudentRepository(StudentDbContext context)
        {
            this._db = context;
        }
        public async Task AddAsync(Student entity)
        {

            await _db.Students.AddAsync(entity);
        }

        public void Delete(Student entity)
        {
            var index = _db.Students.Find(entity);
            if (index != null)
            {
                _db.Students.Remove(entity);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var en = await _db.Students.SingleOrDefaultAsync(p => p.Id == id);
            if (en != null)
            {
                _db.Students.Remove(en);
            }
        }


        public IQueryable<Student> FindAll()
        {

            return _db.Students.AsQueryable();
        }

        public IQueryable<Student> GetAllWithDetails()
        {
            return _db.Students;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var sources = await _db.Students
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            return sources;
        }

        public async Task<Student> GetByIdWithDetailsAsync(int id)
        {
            return await _db.Students.FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(Student entity)
        {

            _db.Students.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
    }
}
