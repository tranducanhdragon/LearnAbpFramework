using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Borrows;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectMapping;

namespace Acme.BookStore.Web.Pages.Books
{
    public class BookCartModalModel : BookStorePageModel
    {
        [BindProperty]
        public List<CartViewModal> lstBookCart { get; set; }
        private readonly IBorrowAppService _borrowApp;

        public BookCartModalModel(IBorrowAppService borrowApp)
        {
            _borrowApp = borrowApp;
        }
        public async Task OnGetAsync(PagedAndSortedResultRequestDto input)
        {
            var lstResult = await _borrowApp.GetListAsync(input);
            //tranfer list BorrowDto to list CartViewModal
            var borrowDtos = lstResult.Items.Select(x =>
                {
                    var borrowDto = ObjectMapper.Map<BorrowDto, CartViewModal>(x);
                    return borrowDto;
                }
            ).ToList();
            lstBookCart = borrowDtos;

        }
        public class CartViewModal
        {
            [HiddenInput]
            public Guid BookId { get; set; } = Guid.Empty;
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
