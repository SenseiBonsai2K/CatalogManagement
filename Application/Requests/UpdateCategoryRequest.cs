using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests
{
    public class UpdateCategoryRequest
    {
        public int Id { get; set; }
        public AddCategoryRequest AddCategoryRequest { get; set; }
    }
}
