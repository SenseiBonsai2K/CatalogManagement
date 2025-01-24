using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests
{
    public class UpdateApparelRequest
    {
        public int Id { get; set; }
        public AddApparelRequest AddApparelRequest { get; set; }
    }
}
