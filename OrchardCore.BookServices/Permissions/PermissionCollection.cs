using OrchardCore.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardCore.BookServices.Permissions
{
    public class PermissionCollection : IPermissionProvider
    {
        public static readonly Permission GetBooks 
            = new Permission("GetBooks", "Lấy danh sách sách");
        public static readonly Permission GetAuthors 
            = new Permission("GetAuthors", "Lấy danh sách tác giả");
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            yield return new PermissionStereotype
            {
                Name = "Administrator",
                Permissions = new[]
                {
                    GetBooks,
                    GetAuthors
                }
            };
        }

        public Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return Task.FromResult(new[]
            {
                GetBooks,
                GetAuthors
            }
           .AsEnumerable());
        }
    }
}
