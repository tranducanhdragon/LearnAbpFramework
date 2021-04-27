using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Genres
{
    public class CreateUpdateGenreDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
    }
}