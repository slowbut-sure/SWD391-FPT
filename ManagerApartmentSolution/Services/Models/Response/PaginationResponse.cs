using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response
{
    public class PaginationResponse<T>
    {
        public T Data { get; set; }
        public int Page {  get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public string Message { get; set; }
    }
}
