using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.ApplicationCore.Models.Request
{
    public class PromotionRequestModel
    {
        public int id { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string name { get; set; }

        [Column(TypeName = "nvarchar(2048)")]
        public string description { get; set; }

        public double discount { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }
    }
}
