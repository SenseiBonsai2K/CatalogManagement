using CatalogManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests
{
    public class UpdateUserRequest
    {
        public int Id { get; set; }
        public AddUserRequest AddUserRequest { get; set; }
    }
}
