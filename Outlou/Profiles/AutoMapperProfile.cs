using AutoMapper;
using Outlou.DataModels;
using Outlou.DomainModels;

namespace Outlou.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Feed, FeedDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<ReadNews, ReadNewsDto>().ReverseMap();
        }
    }
}
