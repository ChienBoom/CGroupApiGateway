using System.ComponentModel.DataAnnotations;

namespace CShop.DTO
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string PictureUrl { get; set; }
        public string Description { get; set; }
    }
}
