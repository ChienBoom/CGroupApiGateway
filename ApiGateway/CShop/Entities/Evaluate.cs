using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CShop.Entities
{
    [Table("Evaluate")]
    public class Evaluate
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [MaxLength(2000)]
        public string Comment { get; set; }
        public int NumberApprovals { get; set; }
        public int NumberDisApprovals { get; set; }
        [NotMapped]
        public User? User { get; set; }
        [NotMapped]
        public Product? Product { get; set; }
    }
}
