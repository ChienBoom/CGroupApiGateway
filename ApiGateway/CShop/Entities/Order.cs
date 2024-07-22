using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CShop.Entities
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        public DateTime OrderAt { get; set; }
        public string Status { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
        public bool IsDelete { get; set; }
        [NotMapped]
        public User? User { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
