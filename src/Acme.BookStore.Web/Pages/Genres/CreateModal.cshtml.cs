using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Acme.BookStore.Web.Pages.Genres
{
    public class CreateModalModel : BookStorePageModel
    {
        public CreateGenreViewModel Genre { get; set; }
        public void OnGet()
        {
            Genre = new CreateGenreViewModel();
        }

        public class CreateGenreViewModel
        {
            [Required]
            [StringLength(128)]
            public string Name { get; set; }

        }
    }
}
