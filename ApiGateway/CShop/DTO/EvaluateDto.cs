using CShop.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CShop.DTO
{
    public class EvaluateDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public string Comment { get; set; }
        public int NumberApprovals { get; set; }
        public int NumberDisApprovals { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
