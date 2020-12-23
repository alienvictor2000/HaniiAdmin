using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn2.Models
{
    [Table("orders")]
    public class Order
    {
        public int Id { get; set; }
        public int Or_transaction_id { get; set; }
        public int Or_product_id { get; set; }
        public string Or_product_name { get; set; }
        public int Or_qty { get; set; }
        public int Or_price { get; set; }

    }
}
