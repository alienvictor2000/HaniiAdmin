using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn2.Models
{
    [Table("articles")]
    public class Article
    {
        public int Id { get; set; }
        public string A_name { get; set; }
        public string A_content { get; set; }
        [NotMapped]
        public IFormFile A_avatar_file { get; set; }
        public string A_avatar { get; set; }
    }
}
