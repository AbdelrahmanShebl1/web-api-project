using System.ComponentModel.DataAnnotations;
using web_api_project.Models.enums;
using web_api_project.Models.PhoneFilter;

namespace web_api_project.Models
{
    public class Mobile : MobilesAndAccessories
    {
        [EnumDataType(typeof(PhoneRam))]
        public string Ram { get; set; }
        public string? GPU { get; set; }
        [EnumDataType(typeof(PhoneOS))]

        public string OS { get; set; }
        [EnumDataType(typeof(Color))]
        public string? Color { get; set; }

        public string? CPU { get; set; }

        public float Width { get; set; }
        public float Height { get; set; }
        public float Thickness { get; set; }
        public float Weight { get; set;}
    }
}
 