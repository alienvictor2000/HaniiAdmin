using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn2.Models
{
    public class TransJoinOrder
    {
        [Key]
        public int Id { get; set; }
        public string Tr_name { get; set; }
        public int Tr_total { get; set; }
        public string Tr_address { get; set; }
        public string Tr_phone { get; set; }
        public bool Tr_status { get; set; }
        public string Tr_note { get; set; }
        public int Or_product_id { get; set; }
        public int Or_qty { get; set; }
        public int Or_price { get; set; }
    }
}
