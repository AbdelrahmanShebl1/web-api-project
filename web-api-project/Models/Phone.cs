using System.ComponentModel.DataAnnotations;
using web_api_project.Models.enums;
using web_api_project.Models.PhoneFilter;

namespace web_api_project.Models
{
    public class Phone : Mobile
    {
        [EnumDataType(typeof(PhoneRam))]
        public PhoneRam Ram { get; set; }
        public string? GPU { get; set; }
        [EnumDataType(typeof(PhoneOS))]

        public PhoneOS OS { get; set; }
        [EnumDataType(typeof(Color))]

        public string? CPU { get; set; }

        public float Width { get; set; }
        public float Height { get; set; }
        public float Thickness { get; set; }
        public float Weight { get; set;}
    }
}
