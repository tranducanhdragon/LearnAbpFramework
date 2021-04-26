using Acme.BookStore.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Genres
{
    public class GenreAppService : CrudAppService<
            Genre, //The Book entity
            GenreDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateGenreDto>, //Used to create/update a book
        IGenreAppService //implement the IBookAppService
    {
        public GenreAppService(IRepository<Genre, Guid> repository) : base(repository)
        {
        }
    }
}
