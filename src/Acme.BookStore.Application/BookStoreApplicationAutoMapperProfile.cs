using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using AutoMapper;

namespace Acme.BookStore
{
    public class BookStoreApplicationAutoMapperProfile : Profile
    {
        public BookStoreApplicationAutoMapperProfile()
        {
            CreateMap<Book, GenreDto>();
            CreateMap<CreateUpdateGenreDto, Book>();

            CreateMap<Author, AuthorDto>();
            CreateMap<Author, AuthorLookupDto>();
        }
    }
}
