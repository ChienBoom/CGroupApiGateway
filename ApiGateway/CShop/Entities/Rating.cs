using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CShop.Entities
{
    [Table("Rating")]
    public class Rating
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public double Star {  get; set; }
        [NotMapped]
        public User? User { get; set; }
        [NotMapped]
        public Product? Product { get; set; }
    }
}
