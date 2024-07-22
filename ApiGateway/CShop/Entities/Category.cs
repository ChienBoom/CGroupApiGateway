using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CShop.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string NumberProduct { get; set; }
        public string PictureUrl { get; set; }
        public string Status { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<Product>? Products { get; set; }
    }
}
