using CShop.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CShop.DTO
{
    public class ProductDetailDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
    }
}
