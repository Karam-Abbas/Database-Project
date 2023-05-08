using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class Product
    {
        [Key]
        public int product_code { get; set; }
        [Required]
        [DisplayName("Product Name")]
        public string product_name { get; set; }
        [Required]
        [DisplayName("Product Cost")]
        public int product_cost { get; set; }
        [Required]
        [DisplayName("Product Expiry")]
        public DateTime product_expiry { get; set; }
        [Required]
        [DisplayName("Product Type")]
        public string product_type { get; set; }
        [Required]
        [DisplayName("Product Color")]
        public string product_color { get; set; }
        [Required]
        [DisplayName("Product Weight")]
        public int product_weight { get; set; }
        [Required]
        [DisplayName("Product Final Price")]
        public int product_final_price { get; set; }
    }
}