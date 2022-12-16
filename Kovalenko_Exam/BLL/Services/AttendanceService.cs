using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class AttendanceService : IAttendanceService
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;

        public AttendanceService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public IEnumerable<AttendanceModel> GetAll()
        {
            var cnt = (float)this._uow.AssignmentRepository.GetAllWithDetails().Count();

            Console.WriteLine(cnt);

            var lst = new List<AttendanceModel>();
            var usrs = _uow.StudentRepository.GetAllWithDetails();

            foreach (var item in usrs)
            {
                var tmp = new AttendanceModel();
                tmp.StudentId = item.Id;

                var ass = (float)_uow.EstimateRepository.GetAllWithDetails().Where(p => p.StudentId == item.Id).Count();

                tmp.AttendacePercentage = (int) (ass / cnt * 100);
                lst.Add(tmp);
            }

            return lst;

        }
    }
}
