using System.ComponentModel.DataAnnotations;

namespace CShop.DTO
{
    public class DiscountDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal Value { get; set; }
        public bool IsDeleted { get; set; }
    }
}
