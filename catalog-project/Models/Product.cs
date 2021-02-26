  using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace catalog_project.Models
{
    public class Product
    {

        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [Range(0, 10000000, ErrorMessage = "price must me grater than 0 and les than 1000000")]
        public float price { get; set; }
        [Required]
        [Range(0, 10000000, ErrorMessage = "price must me grater than 0 and les than 1000000")]
        public float amount { get; set; }
        [Required]
        public DateTime creationDate { get; set; }
        [DisplayName("category")]
        [Required]
        public int categoryId { get; set; }

    }
}
