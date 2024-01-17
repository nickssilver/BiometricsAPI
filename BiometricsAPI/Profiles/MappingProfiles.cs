namespace BiometricsAPI.Profiles
{
    using AutoMapper;
    using BiometricsAPI.Models;
    using Microsoft.Win32;
    using System;

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

            //Biometric data model
            /*CreateMap<BiometricModel, BiometricModel>()
               .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
               .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.StudentName))
               .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
               .ForMember(dest => dest.Arrears, opt => opt.MapFrom(src => src.Arrears))
            .ForMember(dest => dest.Fingerprint1, opt => opt.MapFrom(src => src.Fingerprint1))
            .ForMember(dest => dest.Fingerprint2, opt => opt.MapFrom(src => src.Fingerprint2));*/
        }

        private void ForMember(Func<object, object> value1, Func<object, object> value2)
        {
            throw new NotImplementedException();
        }
    }

}
