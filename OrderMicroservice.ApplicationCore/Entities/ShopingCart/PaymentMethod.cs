using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Entities.ShopingCart
{
    public class PaymentMethod
    {
        public int Id { get; set; }

        [Column("Payment_Type_Id")]
        public int PaymentTypeId { get; set; }

        public string Provider { get; set; }

        public string AccountNumber { get; set; }

        public DateTime Expiry { get; set; }

        public bool isDefault { get; set; }

        public PaymentType PaymentType { get; set; }

        [Column("Customer_ID")]
        public int CustomerID { get; set; }

    }
}
