using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Genres
{
    public class CreateUpdateGenreDto
    {
        public Guid GenreId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }
    }
}