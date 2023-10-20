using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response
{
    public class LoginResponse<T>
    {
        public T Data { get; set; }
        public string Token { get; set; }
        public bool Success { get; set; }
        public string Messenger { get; set; }
    }
}
