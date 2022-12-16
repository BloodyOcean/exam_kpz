using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAssignmentRepository AssignmentRepository { get; }
        IStudentRepository StudentRepository { get; }
        IEstimateRepository EstimateRepository { get; }
        IExamRepository ExamRepository { get; }
        Task<int> SaveAsync();
    }
}
