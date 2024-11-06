
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Entities.OrderHistory
{
    public class Order_Detail
    {
        public int Id { get; set; }
        [Column("Order_Id")]
        public int OrderId { get; set; }
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public Order Order { get; set; }
    }
}
