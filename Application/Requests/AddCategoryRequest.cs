using CatalogManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests
{
    public class AddCategoryRequest
    {
        public string Name { get; set; }

        public Category ToEntity()
        {
            return new Category { Name = this.Name };
        }
    }
}
