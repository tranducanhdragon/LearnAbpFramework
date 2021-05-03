using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.BookStore.Web.Pages.Books
{
    public class CreateBorrowModalModel : BookStorePageModel
    {
        [BindProperty]
        public BookBorrow bookBorrow { get; set; }

        public void OnGet(Guid id, Guid userId)
        {
            bookBorrow = new BookBorrow();
            bookBorrow.Id = id;
            bookBorrow.UserId = userId;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            return NoContent();
        }

        public class BookBorrow
        {
            [HiddenInput]
            public Guid Id { get; set; } = Guid.Empty;
            [HiddenInput]
            public Guid UserId { get; set; } = Guid.Empty;
            [Required]
            [DataType(DataType.Date)]
            public DateTime NgayMuon { get; set; } = DateTime.Now;
            [Required]
            [DataType(DataType.Date)]
            public DateTime NgayHenTra { get; set; } = DateTime.Now;
            [Required]
            public int SoLuong { get; set; }
        }
    }
}
