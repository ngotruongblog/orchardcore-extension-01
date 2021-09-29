using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardCore.BookServices.Models
{
    public class OutputInfo
    {
        public StatusMessage Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
    public enum StatusMessage
    {
        Success = 1,
        Error = 2,
    }
    public static class MessageConst
    {
        public const string Success = "Success";
        public const string Error = "Error";
    }
}
