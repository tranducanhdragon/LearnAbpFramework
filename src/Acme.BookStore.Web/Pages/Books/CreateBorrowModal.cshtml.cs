using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Acme.BookStore.Borrows;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.BookStore.Web.Pages.Books
{
    public class CreateBorrowModalModel : BookStorePageModel
    {
        [BindProperty]
        public CreateBookBorrowViewModel bookBorrow { get; set; }
        private readonly IBorrowAppService _borrowAppService;
        public CreateBorrowModalModel(IBorrowAppService borrowAppService)
        {
            _borrowAppService = borrowAppService;
        }

        public void OnGet(Guid bookId, Guid userId)
        {
            bookBorrow = new CreateBookBorrowViewModel();
            bookBorrow.BookId = bookId;
            bookBorrow.UserId = userId;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _borrowAppService.CreateAsync(ObjectMapper.Map<CreateBookBorrowViewModel, CreateUpdateBorrowDto>(bookBorrow));
            return NoContent();
        }

        public class CreateBookBorrowViewModel
        {
            [HiddenInput]
            public Guid BookId { get; set; } = Guid.Empty;
            [HiddenInput]
            public Guid UserId { get; set; } = Guid.Empty;
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
}
