using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Genres
{
    public interface IGenreAppService :
        ICrudAppService< //Defines CRUD methods
            GenreDto, //Used to show genres
            Guid, //Primary key of the genre entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateGenreDto> //Used to create/update a genre
    {
    }
}