using eIdentificator.Application.Models;
using eIdentificator.Domain;
using AutoMapper;

namespace eIdentificator.Application.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();
        }
    }
}
