using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.Borrows;
using Acme.BookStore.Genres;
using AutoMapper;
using System.Collections.Generic;

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

            //Borrow Mapped
            CreateMap<Pages.Books.CreateBorrowModalModel.CreateBookBorrowViewModel, CreateUpdateBorrowDto>();
            CreateMap<BorrowDto, Pages.Books.BookCartModalModel.CartViewModal>();
        }
    }
}
