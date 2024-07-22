using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CShop.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Address { get; set; }
        public string? PictureUrl { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<Evaluate>? Evaluates { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<Rating>? Ratings { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<Order>? Orders { get; set; }
    }
}
