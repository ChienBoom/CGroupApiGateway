using System.ComponentModel.DataAnnotations;

namespace CShop.DTO
{
    public class BrandDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
