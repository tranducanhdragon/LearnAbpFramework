using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Borrows
{
    public class Borrow : AuditedAggregateRoot<Guid>
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public int Quantity { get; set; }
    }
}
