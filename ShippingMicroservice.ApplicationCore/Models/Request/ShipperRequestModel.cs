using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Models.Request
{
    public class ShipperRequestModel
    {
        public int id { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string name { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string email { get; set; }

        public string phone { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string contactPerson { get; set; }
    }
}
