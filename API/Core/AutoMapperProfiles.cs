using AutoMapper;
using ReactivitiesV1.Domain;
using ReactivitiesV1.DTO;
using ReactivitiesV1.DTO.Post;

namespace ReactivitiesV1.Core
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ModifyPost, Post>();
            CreateMap<EditPostDto, Post>();
        }
    }
}