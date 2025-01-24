using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Application.Services
{
    public class PasswordService
    {
        private readonly string _pepper;

        public PasswordService(IConfiguration configuration)
        {
            _pepper = configuration["Pepper"] ?? throw new InvalidOperationException("Pepper configuration is not set.");
        }

        public string HashPassword(string password)
        {
            int workfactor = 12;
            string pepperedPassword = password + _pepper;
            return BCrypt.Net.BCrypt.HashPassword(pepperedPassword, workfactor);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            string pepperedPassword = password + _pepper;
            return BCrypt.Net.BCrypt.Verify(pepperedPassword, hashedPassword);
        }
    }
}
