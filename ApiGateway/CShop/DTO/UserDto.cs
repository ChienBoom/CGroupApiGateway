using CShop.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CShop.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string? PictureUrl { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
        public List<Evaluate> Evaluates { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Order> Orders { get; set; }
    }
}
