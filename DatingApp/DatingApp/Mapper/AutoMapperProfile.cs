using AutoMapper;
using DatingApp.Api.Extensions;
using DatingApp.DataModel.Entities;
using DatingApp.ServiceModel.DTOs.Request;
using DatingApp.ServiceModel.DTOs.Response;
using System.Linq;

namespace DatingApp.Api.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src =>
                  src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateofBirth.Age()));
            CreateMap<Photo, PhotoDto>();
            CreateMap<User, RegisterDto>();
            CreateMap<User, LoginDto>().ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url)); 
            CreateMap<User, UserDetailsDto>();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<User, LikeDto>().ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url)); ;
            CreateMap<Messages, MessageDto>()
               .ForMember(dest => dest.SenderPhotoUrl, opt => opt.MapFrom(src =>
                   src.Sender.Photos.FirstOrDefault(x => x.IsMain).Url))
               .ForMember(dest => dest.RecipientPhotoUrl, opt => opt.MapFrom(src =>
                   src.Receipent.Photos.FirstOrDefault(x => x.IsMain).Url));
           
           
        }
    }
}
