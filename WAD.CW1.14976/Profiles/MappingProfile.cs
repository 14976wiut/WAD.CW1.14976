using AutoMapper;
using WAD.CW1._14976.DTOs;
using WAD.CW1._14976.Models;

namespace WAD.CW1._14976.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDTO>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));

            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name));

            CreateMap<AuthorDTO, Author>();
            CreateMap<BookDTO, Book>();

            CreateMap<AuthorCreateDTO, Author>().ReverseMap();
            CreateMap<AuthorUpdateDTO, Author>().ReverseMap();
        }
    }
}
