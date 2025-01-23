using CatalogManagement.Models.Entities;

namespace CatalogManagement.DTOs
{
    public class ApparelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }

        public ApparelDTO(Apparel apparel)
        {
            this.Id = apparel.Id;
            this.Name = apparel.Name;
            this.Description = apparel.Description;
            this.ImageUrl = apparel.ImageUrl;
            this.Size = apparel.Size;
            this.Material = apparel.Material;
            this.Brand = apparel.Brand;
            this.Price = apparel.Price;
            this.Stock = apparel.Stock;
            this.CategoryId = apparel.CategoryId;
            this.Category = new CategoryDTO(apparel.Category);
        }
    }
}
