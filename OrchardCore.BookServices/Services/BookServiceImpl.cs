using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;
using OrchardCore.BookServices.Models;

namespace OrchardCore.BookServices.Services
{
    public class BookServiceImpl : IBookService
    {
        private IOptions<ConnectionStrings> _connecString;
        public BookServiceImpl(IOptions<ConnectionStrings> connecString)
        {
            _connecString = connecString;
        }
        public async Task<List<Book>> GetBooks()
        {
            List<Book> list = new List<Book>();
            using (var connection = new SqlConnection(_connecString.Value.BookServiceConnection))
            {
                string sql = "select * from Book";
                list = (await connection.QueryAsync<Book>(sql)).ToList();
            }

            return list;
        }

        public async Task<List<Author>> GetAuthors()
        {
            List<Author> list = new List<Author>();
            using (var connection = new SqlConnection(_connecString.Value.BookServiceConnection))
            {
                string sql = "select * from Author";
                list = (await connection.QueryAsync<Author>(sql)).ToList();
            }

            return list;
        }
    }
}
