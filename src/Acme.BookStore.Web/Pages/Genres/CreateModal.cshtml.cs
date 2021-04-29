using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Genres;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Acme.BookStore.Web.Pages.Genres
{
    public class CreateModalModel : BookStorePageModel
    {
        [BindProperty]
        public CreateGenreViewModel Genre { get; set; }
        private readonly IGenreAppService genreAppService;

        public CreateModalModel(IGenreAppService genreApp)
        {
            genreAppService = genreApp;
        }

        public void OnGet()
        {
            Genre = new CreateGenreViewModel();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await genreAppService.CreateAsync(ObjectMapper.Map<CreateGenreViewModel, CreateUpdateGenreDto>(Genre));
            return NoContent();

        }

        public class CreateGenreViewModel
        {
            [Required]
            [StringLength(128)]
            public string Name { get; set; }

        }
    }
}
