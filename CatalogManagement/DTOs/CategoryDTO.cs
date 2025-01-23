using CatalogManagement.Models.Entities;

namespace CatalogManagement.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CategoryDTO(Category category)
        {
            this.Name = category.Name;
            this.Id = category.Id;
        }
    }
}
