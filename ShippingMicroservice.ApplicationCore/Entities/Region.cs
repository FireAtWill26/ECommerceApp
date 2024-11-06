using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class Region
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string Name { get; set; }

        public List<Shipper_Region> Shipper_Regions { get; set; }
    }
}
