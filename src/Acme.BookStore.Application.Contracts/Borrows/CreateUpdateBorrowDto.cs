using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.BookStore.Borrows
{
    public class CreateUpdateBorrowDto
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; } = DateTime.Now;
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpectedReturnDate { get; set; } = DateTime.Now;
        [Required]
        public int Quantity { get; set; }
    }

}
