using CShop.Entities;

namespace CShop.DTO
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SupplierId { get; set; }
        public Guid BrandId { get; set; }
        public int NumberSold { get; set; }
        public int NumberStock { get; set; }
        public double Star { get; set; }
        public int NumberEvaluate { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public Brand Brand { get; set; }
    }
}
