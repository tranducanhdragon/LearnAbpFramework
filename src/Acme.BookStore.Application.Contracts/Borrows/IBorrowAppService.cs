using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;


namespace Acme.BookStore.Borrows
{
    public interface IBorrowAppService :
        ICrudAppService<
            BorrowDto,//user to map Borrow
            Guid,//primary key of Borrow
            PagedAndSortedResultRequestDto,
            CreateUpdateBorrowDto>//user to create/update Borrow
    {
    }
}
