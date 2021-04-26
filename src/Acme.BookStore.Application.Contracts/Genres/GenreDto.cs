using System;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Genres
{
    public class GenreDto : AuditedEntityDto<Guid>
    {
        public Guid GenreId { get; set; }
        public string Name { get; set; }
    }
}