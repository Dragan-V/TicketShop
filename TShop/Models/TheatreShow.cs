using System.ComponentModel.DataAnnotations;

namespace TShop.Models
{
    public class TheatreShow
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public String Place { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

    }
}
