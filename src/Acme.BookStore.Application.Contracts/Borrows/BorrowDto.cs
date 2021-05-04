using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Borrows
{
    public class BorrowDto : AuditedEntityDto<Guid>
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public int Quantity { get; set; }
    }
}
