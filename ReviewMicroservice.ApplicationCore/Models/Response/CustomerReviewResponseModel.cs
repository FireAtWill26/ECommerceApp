using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.ApplicationCore.Models.Response
{
    public class CustomerReviewResponseModel
    {
        public int id { get; set; }

        public int customerId { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string customerName { get; set; }

        public int orderId { get; set; }

        public DateTime orderDate { get; set; }

        public int productId { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string productName { get; set; }

        public double ratingValue { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string comment { get; set; }

        public DateTime reviewDate { get; set; }
    }
}

