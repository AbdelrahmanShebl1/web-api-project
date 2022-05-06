using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_project.Models
{
    public abstract class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        //public ICollection<string> Media { get; set; } = new List<string>();
        public virtual ICollection<Media> Media { get; set; } = new List<Media>();

        public virtual Manufacturer? Manufacturer { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerID { get; set; }

        public int Warranty { get; set; }

        [Required]
        public int UnitInStock { get; set; }

        public string? Description { get; set; }
    }
}