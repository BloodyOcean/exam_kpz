using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentDbContext _db;

        private readonly IAssignmentRepository _assignmentRepository;

        private readonly IStudentRepository _studentRepository;

        private readonly IEstimateRepository _estimateRepository;

        private readonly IExamRepository _examRepository;


        public UnitOfWork(StudentDbContext context,
            IAssignmentRepository assignmentRepository,
            IStudentRepository studentRepository,
            IEstimateRepository estimateRepository,
            IExamRepository examRepository)
        {
            _assignmentRepository = assignmentRepository;
            _studentRepository = studentRepository;
            _estimateRepository = estimateRepository;
            _examRepository = examRepository;
            

            this._db = context ?? throw new ArgumentNullException(nameof(context)); ;
        }

        public IAssignmentRepository AssignmentRepository => _assignmentRepository ?? throw new ArgumentNullException(nameof(_assignmentRepository));

        public IStudentRepository StudentRepository => _studentRepository ?? throw new ArgumentNullException(nameof(_studentRepository));

        public IEstimateRepository EstimateRepository => _estimateRepository ?? throw new ArgumentNullException(nameof(_estimateRepository));

        public IExamRepository ExamRepository => _examRepository ?? throw new ArgumentNullException(nameof(_examRepository));

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
