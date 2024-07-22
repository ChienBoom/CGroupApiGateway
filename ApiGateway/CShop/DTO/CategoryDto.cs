using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CShop.DTO
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NumberProduct { get; set; }
        public string PictureUrl { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
