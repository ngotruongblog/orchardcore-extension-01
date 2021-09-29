using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.BookServices.Models;

namespace OrchardCore.BookServices.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetBooks();
        Task<List<Author>> GetAuthors();
    }
}
