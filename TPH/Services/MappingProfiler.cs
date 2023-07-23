using AutoMapper;
using TPH.DTOs;
using TPH.Models;

namespace TPH.Services
{
	public class MappingProfiler : Profile
	{
        public MappingProfiler()
        {
            CreateMap<Student, StudentRegisterDto>()
                .ReverseMap();
        }
    }
}
