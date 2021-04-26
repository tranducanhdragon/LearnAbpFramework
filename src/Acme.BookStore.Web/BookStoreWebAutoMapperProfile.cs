using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using AutoMapper;

namespace Acme.BookStore.Web
{
    public class BookStoreWebAutoMapperProfile : Profile
    {
        public BookStoreWebAutoMapperProfile()
        {
            CreateMap<GenreDto, CreateUpdateGenreDto>();

            CreateMap<Pages.Authors.CreateModalModel.CreateAuthorViewModel, CreateAuthorDto>();

            CreateMap<AuthorDto, Pages.Authors.EditModalModel.EditAuthorViewModel>();
            CreateMap<Pages.Authors.EditModalModel.EditAuthorViewModel, UpdateAuthorDto>();

            CreateMap<Pages.Books.CreateModalModel.CreateBookViewModel, CreateUpdateGenreDto>();
            CreateMap<GenreDto, Pages.Books.EditModalModel.EditBookViewModel>();
            CreateMap<Pages.Books.EditModalModel.EditBookViewModel, CreateUpdateGenreDto>();
        }
    }
}
