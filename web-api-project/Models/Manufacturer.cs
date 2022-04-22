﻿namespace web_api_project.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
