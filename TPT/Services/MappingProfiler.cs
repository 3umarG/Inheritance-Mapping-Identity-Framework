using AutoMapper;
using TPT.DTOs;
using TPT.Models;

namespace TPT.Services
{
	public class MappingProfiler : Profile
	{
        public MappingProfiler()
        {
            CreateMap<Student, StudentRegisterDto>()
                .ReverseMap();

            CreateMap<Teacher, TeacherRegisterDto>()
                .ReverseMap();
        }
    }
}
