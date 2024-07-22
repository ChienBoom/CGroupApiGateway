using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CShop.Entities
{
    [Table("ProductDetail")]
    public class ProductDetail
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Unit {  get; set; }
        public decimal Price { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
        [NotMapped]
        public Product? Product { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
