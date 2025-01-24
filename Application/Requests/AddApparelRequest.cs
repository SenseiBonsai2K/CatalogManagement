using CatalogManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests
{
    public class AddApparelRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }  
        public int CategoryId { get; set; }

        public Apparel ToEntity()
        {
            return new Apparel
            {
                Name = this.Name,
                Description = this.Description,
                ImageUrl = this.ImageURL,
                Price = this.Price,
                Size = this.Size,
                Material = this.Material,
                Brand = this.Brand,
                Stock = this.Stock,
                CategoryId = this.CategoryId
            };
        }
    }
}
