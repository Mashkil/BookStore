using AutoMapper;
using BookStore.Data.Entities;
using BookStore.Data.Models;

namespace BookStore.MapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookModel, Book>()
                .ForMember(e => e.Id, c => c.Ignore());
        }
    }
}
