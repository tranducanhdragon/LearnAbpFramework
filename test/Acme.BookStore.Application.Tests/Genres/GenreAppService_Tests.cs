using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Acme.BookStore.Genres
{
    public class GenreAppService_Tests : BookStoreApplicationTestBase
    {
        private readonly IGenreAppService _genreAppService;

        public GenreAppService_Tests()
        {
            _genreAppService = GetRequiredService<IGenreAppService>();
        }

        [Fact]
        public async Task Should_Create_A_Valid_Genre()
        {
            //Act
            var result = await _genreAppService.CreateAsync(new CreateUpdateGenreDto { Name = "PhieuLuu" });
            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("PhieuLuu");
        }
    }
}
