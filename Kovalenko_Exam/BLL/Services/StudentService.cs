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
    public class StudentService : IStudentService
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;

        public StudentService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task AddAsync(StudentModel model)
        {
            Console.WriteLine("HERE!!!!");
         
            var element = _mapper.Map<Student>(model);
            await _uow.StudentRepository.AddAsync(element);
            await _uow.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {

            await _uow.StudentRepository.DeleteByIdAsync(modelId);
            await _uow.SaveAsync();
        }

        public IEnumerable<StudentModel> GetAll()
        {
            var res = _mapper.Map<IEnumerable<StudentModel>>(_uow.StudentRepository.GetAllWithDetails());
            return res;
        }

        public async Task<StudentModel> GetByIdAsync(int id)
        {

            var res = await _uow.StudentRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<StudentModel>(res);
        }

        public async Task UpdateAsync(StudentModel model)
        {
            _uow.StudentRepository.Update(_mapper.Map<Student>(model));
            await _uow.SaveAsync();
        }
    }
}
