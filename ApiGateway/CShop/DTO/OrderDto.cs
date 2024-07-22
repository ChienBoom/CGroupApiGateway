using CShop.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CShop.DTO
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderAt { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public User User { get; set; }
    }
}
