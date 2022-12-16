﻿using AutoMapper;
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
    public class AssignmentService : IAssignmentService
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;

        public AssignmentService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        /// <summary>
        /// Adds new task to db
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddAsync(AssignmentModel model)
        {
            if (model.CreationDate > model.ClosureDate)
            {
                throw new Exception("Dates are invalid");
            }

            var element = _mapper.Map<Assignment>(model);
            await _uow.AssignmentRepository.AddAsync(element);
            await _uow.SaveAsync();
        }

        /// <summary>
        /// Removes task with id from db
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(int modelId)
        {
            await _uow.AssignmentRepository.DeleteByIdAsync(modelId);
            await _uow.SaveAsync();
        }

        /// <summary>
        /// Returns all task records from db
        /// </summary>
        /// <returns>Sequence of projects</returns>
        public IEnumerable<AssignmentModel> GetAll()
        {
            var res = _mapper.Map<IEnumerable<AssignmentModel>>(_uow.AssignmentRepository.GetAllWithDetails());
            return res;
        }

        /// <summary>
        /// Returns task with corresponding Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task with corresponding Id</returns>
        public async Task<AssignmentModel> GetByIdAsync(int id)
        {
            var res = await _uow.AssignmentRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<AssignmentModel>(res);
        }

        /// <summary>
        /// Changes task record with corresponding Id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateAsync(AssignmentModel model)
        {
            _uow.AssignmentRepository.Update(_mapper.Map<Assignment>(model));
            await _uow.SaveAsync();
        }
    }
}
