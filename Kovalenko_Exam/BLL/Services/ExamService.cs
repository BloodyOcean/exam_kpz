using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Enitites;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ExamService : IExamService
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;

        public ExamService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task AddAsync(ExamModel model)
        {
            var element = _mapper.Map<Exam>(model);
            await _uow.ExamRepository.AddAsync(element);
            await _uow.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {

            await _uow.ExamRepository.DeleteByIdAsync(modelId);
            await _uow.SaveAsync();
        }

        public IEnumerable<ExamModel> GetAll()
        {
            var res = _mapper.Map<IEnumerable<ExamModel>>(_uow.ExamRepository.GetAllWithDetails());
            return res;
        }

        public async Task<ExamModel> GetByIdAsync(int id)
        {

            var res = await _uow.ExamRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<ExamModel>(res);
        }

        public async Task UpdateAsync(ExamModel model)
        {
            _uow.ExamRepository.Update(_mapper.Map<Exam>(model));
            await _uow.SaveAsync();
        }
    }
}
