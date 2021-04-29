using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.Genres;
using AutoMapper;

namespace Acme.BookStore.Web
{
    public class BookStoreWebAutoMapperProfile : Profile
    {
        public BookStoreWebAutoMapperProfile()
        {
            //Book Mapped
            CreateMap<BookDto, CreateUpdateBookDto>();
            CreateMap<Pages.Books.CreateModalModel.CreateBookViewModel, CreateUpdateBookDto>();
            CreateMap<BookDto, Pages.Books.EditModalModel.EditBookViewModel>();
            CreateMap<Pages.Books.EditModalModel.EditBookViewModel, CreateUpdateBookDto>();

            //Author Mapped
            CreateMap<AuthorDto, Pages.Authors.EditModalModel.EditAuthorViewModel>();
            CreateMap<Pages.Authors.CreateModalModel.CreateAuthorViewModel, CreateAuthorDto>();           
            CreateMap<Pages.Authors.EditModalModel.EditAuthorViewModel, UpdateAuthorDto>();

            //Genre Mapped
            CreateMap<Pages.Genres.CreateModalModel.CreateGenreViewModel, CreateUpdateGenreDto>();
            CreateMap<Pages.Genres.EditModalModel.EditGenreViewModel, CreateUpdateGenreDto>();
        }
    }
}
