using AutoMapper;
using BusinessLibrary.DTO;
using DataAccessLibrary.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
        }


    }
}
