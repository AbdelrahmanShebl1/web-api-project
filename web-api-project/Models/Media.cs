using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_project.Models
{
    public class Media
    {
        public int Id { get; set; }
        public string? ImageURL { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
    }
}
