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

namespace Acme.BookStore.Borrows
{
    [Authorize(BookStorePermissions.Books.Default)]
    public class BorrowAppService : 
        CrudAppService<
            Borrow,
            BorrowDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateBorrowDto
        >,
        IBorrowAppService
    {
        private readonly IRepository<Borrow, Guid> _borrowRepository;
        public BorrowAppService(IRepository<Borrow, Guid> borrowRepository) : base(borrowRepository)
        {
            _borrowRepository = borrowRepository;
        }
    }
}
