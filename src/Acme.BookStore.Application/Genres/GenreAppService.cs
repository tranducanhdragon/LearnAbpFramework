using Acme.BookStore.Authors;
using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(BookStorePermissions.Books.Default)]
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
            GetPolicyName = BookStorePermissions.Genres.Default;
            GetListPolicyName = BookStorePermissions.Genres.Default;
            CreatePolicyName = BookStorePermissions.Genres.Create;
            UpdatePolicyName = BookStorePermissions.Genres.Edit;
            DeletePolicyName = BookStorePermissions.Genres.Create;
        }
        public override async Task<PagedResultDto<GenreDto>> GetListAsync(PagedAndSortedResultRequestDto input) {
            var queryable = await _genre_repo.GetQueryableAsync();
            var query = from gen in queryable select new { gen};

            //paging
            query = query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);
            //Execute query to get List
            var queryResult = await AsyncExecuter.ToListAsync(query);
            //Convert query result to a list of GenreDto object
            var genreDtos = queryResult.Select(x =>
                {
                    var genreDto = ObjectMapper.Map<Genre, GenreDto>(x.gen);
                    return genreDto;
                }
            ).ToList();
            //get total count for pagedResult
            var totalCount = await _genre_repo.CountAsync();

            return new PagedResultDto<GenreDto>(
                totalCount,
                genreDtos
            );       
        }
    }
}
