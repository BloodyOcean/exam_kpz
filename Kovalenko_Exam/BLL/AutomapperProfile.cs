using AutoMapper;
using BLL.Models;
using DAL.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /// <summary>
    /// Converts DTO into DAL entities or DAL entities into DTOs
    /// </summary>
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Assignment, AssignmentModel>()
                .ReverseMap();


            CreateMap<Student, StudentModel>()
                .ReverseMap();


            CreateMap<Estimate, EstimateModel>()
                .ReverseMap();

            CreateMap<Exam, ExamModel>()
                .ReverseMap();
        }
    }
}
