using AutoMapper;
using DemoT3.Contract.Requests;
using DemoT3.Domains;

namespace DemoT3.Application.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserRequest, User>()
            .ForPath(
                    dest => dest.UserDetail.FirstName,
                    opt => opt.MapFrom(s => s.FirstName)
                )
            .ForPath(
                    dest => dest.UserDetail.LastName,
                    opt => opt.MapFrom(s => s.LastName)
                )
            .ForPath(
                    dest => dest.UserDetail.PhoneNumber,
                    opt => opt.MapFrom(s => s.PhoneNumber)
                )
            .ForPath(
                    dest => dest.UserDetail.Address,
                    opt => opt.MapFrom(s => s.Address)
                );

            CreateMap<EditUserRequest, User>()
            .ForPath(
                    dest => dest.UserDetail.FirstName,
                    opt => opt.MapFrom(s => s.FirstName)
                )
            .ForPath(
                    dest => dest.UserDetail.LastName,
                    opt => opt.MapFrom(s => s.LastName)
                )
            .ForPath(
                    dest => dest.UserDetail.PhoneNumber,
                    opt => opt.MapFrom(s => s.PhoneNumber)
                )
            .ForPath(
                    dest => dest.UserDetail.Address,
                    opt => opt.MapFrom(s => s.Address)
                );
            CreateMap<User, EditUserRequest>()
                .ForPath(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(s => s.UserDetail.FirstName)
                )
                .ForPath(
                    dest => dest.LastName,
                    opt => opt.MapFrom(s => s.UserDetail.LastName)
                )
                .ForPath(
                    dest => dest.PhoneNumber,
                    opt => opt.MapFrom(s => s.UserDetail.PhoneNumber)
                )
                .ForPath(
                    dest => dest.Address,
                    opt => opt.MapFrom(s => s.UserDetail.Address)
                );
            CreateMap<User, GetUserRequest>()
                .ForPath(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(s => s.UserDetail.FirstName)
                )
                .ForPath(
                    dest => dest.LastName,
                    opt => opt.MapFrom(s => s.UserDetail.LastName)
                )
                .ForPath(
                    dest => dest.PhoneNumber,
                    opt => opt.MapFrom(s => s.UserDetail.PhoneNumber)
                )
                .ForPath(
                    dest => dest.Address,
                    opt => opt.MapFrom(s => s.UserDetail.Address)
                )
                .ForPath(
                    dest => dest.IdUser,
                    opt => opt.MapFrom(s => s.UserDetail.IdUser)
                );
        }
    }
}
