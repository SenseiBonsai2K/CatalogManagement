using CatalogManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests
{
    public class AddUserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User ToEntity()
        {
            return new User
            {
                Username = this.Username,
                Email = this.Email,
                Password = this.Password,
                Role = User.UserRole.User
            };
        }
    }
}
