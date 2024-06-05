﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ComponentShopAPI.Models
{
    [JsonDerivedType(typeof(Monitor))]
    [JsonDerivedType(typeof(Gpu))]
    public abstract class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImageName { get; set; } = "";
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}