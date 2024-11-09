using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Models.Response
{
    public class ShippingDetailResponseModel
    {
        public int Id { get; set; }

        [Column("Order_Id")]
        public int orderId { get; set; }

        [Column("Shipper_Id")]
        public int shipperId { get; set; }

        [Column("Shipping_Status")]
        public string shippingStatus { get; set; }

        [Column("Tracking_Number")]
        public string trackingNumber { get; set; }
    }
}
