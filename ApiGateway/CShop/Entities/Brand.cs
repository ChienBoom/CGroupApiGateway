using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CShop.Entities
{
    public class Brand
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<Product>? Products { get; set; }
    }
}
