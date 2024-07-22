using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CShop.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public Guid SupplierId { get; set; }
        [Required]
        public Guid BrandId { get; set; }
        public int NumberSold { get; set; }
        public int NumberStock { get; set; }
        public double Star {  get; set; }
        public int NumberEvaluate { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped]
        public Category? Category { get; set; }
        [NotMapped]
        public Supplier? Supplier { get; set; }
        [NotMapped]
        public Brand? Brand { get; set;}
        [NotMapped]
        [JsonIgnore]
        public List<ProductDetail>? ProductDetails { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<Evaluate>? Evaluates { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<Rating>? Ratings { get; set; }
    }
}
