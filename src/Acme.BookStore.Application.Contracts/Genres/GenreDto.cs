using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Acme.BookStore.Genres
{
    public class GenreDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}