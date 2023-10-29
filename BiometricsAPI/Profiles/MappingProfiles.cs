namespace BiometricsAPI.Profiles
{
    using AutoMapper;
    using BiometricsAPI.Models;
    using Microsoft.Win32;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentModel, StudentModel>()
                .ForMember(dest => dest.AdmnNo, opt => opt.MapFrom(src => src.AdmnNo))
                .ForMember(dest => dest.names, opt => opt.MapFrom(src => src.names))
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class))
                .ForMember(dest => dest.StudStatus, opt => opt.MapFrom(src => src.StudStatus))
                .ForMember(dest => dest.Arrears, opt => opt.MapFrom(src => src.Arrears));
        }
    }

}
