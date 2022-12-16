using DAL.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IExamRepository : IRepository<Exam>
    {
        IQueryable<Exam> GetAllWithDetails();
        Task<Exam> GetByIdWithDetailsAsync(int id);
    }
}
