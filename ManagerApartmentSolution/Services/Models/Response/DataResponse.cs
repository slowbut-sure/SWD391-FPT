using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response
{
    public class DataResponse<T>
    {
        public Object Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
