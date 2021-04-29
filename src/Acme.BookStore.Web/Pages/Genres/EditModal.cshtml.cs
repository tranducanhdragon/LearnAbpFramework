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
    public class EditModalModel : BookStorePageModel
    {
        [BindProperty]
        public EditGenreViewModel Genre { get; set; }

        private readonly IGenreAppService _genreAppService;

        public EditModalModel(IGenreAppService genreApp)
        {
            _genreAppService = genreApp;
        }
        public async Task OnGet(Guid id)
        {
            //Create genreDto to map to EditGenreViewModel
            Genre = new EditGenreViewModel();
            Genre.Id = id;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _genreAppService.UpdateAsync(Genre.Id, ObjectMapper.Map<EditGenreViewModel, CreateUpdateGenreDto>(Genre));
                return NoContent();
            }
            catch (Exception e)
            {
                return NoContent();
            }
        }
        public class EditGenreViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }
            [Required]
            [StringLength(128)]
            public string Name { get; set; }
        }
    }
}
