using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ResultService : IResultService
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;

        public ResultService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }
        public IEnumerable<ResultModel> GetAll()
        {
            var s = this._uow.StudentRepository.GetAllWithDetails();
            var lst = new List<ResultModel>();

            foreach (var item in s)
            {
                var tmp = new ResultModel();
                tmp.StudentId = item.Id;
                var mrk = _uow.ExamRepository.GetAllWithDetails().Where(p => p.StudentId == item.Id).FirstOrDefault();

                var cm = mrk.Mark;

                var subjects = _uow.EstimateRepository.GetAllWithDetails().Where(p => p.Id == item.Id);

                foreach (var sbj in subjects)
                {
                    var tm = sbj.Mark ?? 0;
                    cm += tm;
                }

                tmp.Mark = cm;
                lst.Add(tmp);
            }

            return lst;
        }

    }
}
