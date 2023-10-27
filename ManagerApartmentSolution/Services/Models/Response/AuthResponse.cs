using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.Response
{
    public class AuthResponse<T> : DataResponse<T>
    {
        public string? Token { get; set; }
    }
}
