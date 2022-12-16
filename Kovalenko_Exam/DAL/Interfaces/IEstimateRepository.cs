using DAL.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEstimateRepository : IRepository<Estimate>
    {
        IQueryable<Estimate> GetAllWithDetails();
        Task<Estimate> GetByIdWithDetailsAsync(int id);
    }
}
