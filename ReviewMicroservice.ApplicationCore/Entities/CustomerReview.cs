
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.ApplicationCore.Entities
{
    public class CustomerReview
    {
        public int id { get; set; }

        [Column("Customer_Id")]
        public int customerId { get; set; }

        [Column("Customer_Name", TypeName ="nvarchar(256)")]
        public string customerName { get; set; }

        [Column("Order_Id")]
        public int orderId { get; set; }

        [Column("Order_Date")]
        public DateTime orderDate { get; set; }

        [Column("Product_Id")]
        public int productId { get; set; }

        [Column("Product_Name", TypeName = "nvarchar(256)")]
        public string productName { get; set; }

        [Column("Rating_Value")]
        public double ratingValue { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string comment { get; set; }

        [Column("Review_Date")]
        public DateTime reviewDate { get; set; }
    }
}
