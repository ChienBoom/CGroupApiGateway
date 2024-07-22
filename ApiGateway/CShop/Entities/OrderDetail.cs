using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CShop.Entities
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public Guid ProductDetailId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
        [NotMapped]
        public Order? Order { get; set; }
        [NotMapped]
        public ProductDetail? ProductDetail { get; set; }
    }
}
