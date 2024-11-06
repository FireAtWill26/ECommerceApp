using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Entities.OrderHistory
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Order_Date { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int PaymentMethodId { get; set; }
        public string PaymentName { get; set; }
        public string ShippingAddress { get; set; }
        public string ShipMethod { get; set; }
        public decimal BillAmount { get; set; }
        public string Order_Status { get; set; }
        public List<Order_Detail> Order_Details { get; set; }
    }
}
