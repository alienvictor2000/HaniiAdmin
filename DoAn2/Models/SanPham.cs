using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace DoAn2.Models
{
    [Table("products")]
    public class Product
    {
        public int Id { get ; set ; }
        public string Pro_name { get ; set ; }
        public string Pro_slug { get; set; }
        public int Pro_category_id { get ; set ; }
        public int Pro_price { get ; set ; }
        public string Pro_description { get; set; }
        [NotMapped]
        public IFormFile Pro_avatar_file { get ; set ; }
        public string Pro_avatar { get ; set ; }
    }
}
