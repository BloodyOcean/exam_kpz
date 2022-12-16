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
    public class EstimateService : IEstimateService
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;

        public EstimateService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task AddAsync(EstimateModel model)
        {
            var element = _mapper.Map<Estimate>(model);
            await _uow.EstimateRepository.AddAsync(element);
            await _uow.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {

            await _uow.EstimateRepository.DeleteByIdAsync(modelId);
            await _uow.SaveAsync();
        }

        public IEnumerable<EstimateModel> GetAll()
        {
            var res = _mapper.Map<IEnumerable<EstimateModel>>(_uow.EstimateRepository.GetAllWithDetails());
            return res;
        }

        public async Task<EstimateModel> GetByIdAsync(int id)
        {

            var res = await _uow.EstimateRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<EstimateModel>(res);
        }

        public async Task UpdateAsync(EstimateModel model)
        {
            _uow.EstimateRepository.Update(_mapper.Map<Estimate>(model));
            await _uow.SaveAsync();
        }
    }
}
