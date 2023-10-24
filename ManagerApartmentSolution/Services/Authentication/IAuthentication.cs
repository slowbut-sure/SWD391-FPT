using ManagerApartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Authentication
{
    public interface IAuthentication
    {
        public bool Verify(string HashPassword, string InputPassword);
        public string Hash(string password);
        public string GenerateToken(Staff staff, string secretKey, string role);
        public string GenerateToken(Tennant tennant, string secretKey, string role);
        public string GenerateToken(Owner owner, string secretKey, string role);
    }
}
