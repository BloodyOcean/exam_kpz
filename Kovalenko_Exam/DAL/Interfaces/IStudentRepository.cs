using DAL.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        IQueryable<Student> GetAllWithDetails();
        Task<Student> GetByIdWithDetailsAsync(int id);
    }
}
