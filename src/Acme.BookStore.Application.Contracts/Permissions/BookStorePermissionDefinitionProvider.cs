using Acme.BookStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.BookStore.Permissions
{
    public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var bookStoreGroup = context.AddGroup(BookStorePermissions.GroupName, L("Permission:BookStore"));
            //Thêm sửa xóa sách
            var booksPermission = bookStoreGroup.AddPermission(BookStorePermissions.Books.Default, L("Permission:Books"));
            booksPermission.AddChild(BookStorePermissions.Books.Create, L("Permission:Books.Create"));
            booksPermission.AddChild(BookStorePermissions.Books.Edit, L("Permission:Books.Edit"));
            booksPermission.AddChild(BookStorePermissions.Books.Delete, L("Permission:Books.Delete"));

            //Mượn trả sách
            booksPermission.AddChild(BookStorePermissions.Books.Borrow, L("Permission:Books.Borrow"));
            booksPermission.AddChild(BookStorePermissions.Books.Return, L("Permission:Books.Return"));

            //Thêm sửa xóa tác giả
            var authorsPermission = bookStoreGroup.AddPermission(BookStorePermissions.Authors.Default, L("Permission:Authors"));
            authorsPermission.AddChild(BookStorePermissions.Authors.Create, L("Permission:Authors.Create"));
            authorsPermission.AddChild(BookStorePermissions.Authors.Edit, L("Permission:Authors.Edit"));
            authorsPermission.AddChild(BookStorePermissions.Authors.Delete, L("Permission:Authors.Delete"));

            //Thêm sửa xóa thể loại
            var genresPermission = bookStoreGroup.AddPermission(BookStorePermissions.Genres.Default, L("Permission:Genres"));
            genresPermission.AddChild(BookStorePermissions.Genres.Create, L("Permission:Genres.Create"));
            genresPermission.AddChild(BookStorePermissions.Genres.Edit, L("Permission:Genres.Edit"));
            genresPermission.AddChild(BookStorePermissions.Genres.Delete, L("Permission:Genres.Delete"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BookStoreResource>(name);
        }
    }
}
