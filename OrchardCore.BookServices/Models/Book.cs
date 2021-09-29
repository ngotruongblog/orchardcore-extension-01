using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardCore.BookServices.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int AuthorId { get; set; }
    }
}
