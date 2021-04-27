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
            Genre, //The Genre entity
            GenreDto, //Used to show genres
            Guid, //Primary key of the genre entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateGenreDto>, //Used to create/update a genre
    IGenreAppService //implement the IGenreAppService
    {
        private readonly IRepository<Genre, Guid> _genre_repo;
        public GenreAppService(IRepository<Genre, Guid> genre_repo) : base(genre_repo)
        {
            _genre_repo = genre_repo;
        }
        public override async Task<PagedResultDto<GenreDto>> GetListAsync(PagedAndSortedResultRequestDto input) {
            var genreDtos = _genre_repo.GetListAsync();
            return new PagedResultDto<GenreDto>();       
        }
    }
}
