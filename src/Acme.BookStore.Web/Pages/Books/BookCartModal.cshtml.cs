using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Acme.BookStore.Borrows;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.ObjectMapping;

namespace Acme.BookStore.Web.Pages.Books
{
    public class BookCartModalModel : BookStorePageModel
    {
        [BindProperty]
        public CartViewModal cartModal { get; set; }
        //public List<SelectListItem> Books { get; set; }

        private readonly IBorrowAppService _borrowApp;
        private readonly IBookAppService _bookApp;

        public BookCartModalModel(IBorrowAppService borrowApp, IBookAppService bookApp)
        {
            _borrowApp = borrowApp;
            _bookApp = bookApp;
        }
        public async Task OnGetAsync(PagedAndSortedResultRequestDto input)
        {
            cartModal = new CartViewModal();

            var lstResult = await _borrowApp.GetListAsync(input);
            
            //tranfer list BorrowDto to list CartViewModal
            var borrowDtos = lstResult.Items.Select(x =>
                {
                    var borrowDto = ObjectMapper.Map<BorrowDto, BookCartViewModal>(x);
                    return borrowDto;
                }
            ).ToList();
            cartModal.BookCart = borrowDtos;

            //get list bookLookupDto and set to BookName in cartModal
            var lstBookLookup = await _bookApp.GetBookLookupAsync();
            foreach(var i in cartModal.BookCart)
            {
                i.BookName = lstBookLookup.Items.Where(x => x.Id == i.BookId).Select(x => x.Name).FirstOrDefault().ToString();
            }
            //Books = lstBookLookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

        }
        public class CartViewModal
        {
            public List<BookCartViewModal> BookCart { get; set; }
        }
        public class BookCartViewModal
        {
            //[HiddenInput]
            //[SelectItems(nameof(Books))]
            public Guid BookId { get; set; } = Guid.Empty;
            [StringLength(128)]
            public string BookName { get; set; }
            [HiddenInput]
            public Guid UserId { get; set; } = Guid.Empty;
            [DataType(DataType.Date)]
            public DateTime BorrowDate { get; set; } = DateTime.Now;
            [DataType(DataType.Date)]
            public DateTime ExpectedReturnDate { get; set; } = DateTime.Now;
            public int Quantity { get; set; }
        }
        
    }
}
