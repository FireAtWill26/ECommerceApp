
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.ApplicationCore.Entities
{
    public class Promotion
    {
        public int id { get; set; }

        [Column(TypeName ="nvarchar(256)")]
        public string name { get; set; }

        [Column(TypeName = "nvarchar(2048)")]
        public string description { get; set; }

        public double discount { get; set; }

        [Column("Start_Date")]
        public DateTime startDate { get; set; }

        [Column("End_Date")]
        public DateTime endDate { get; set; }

        public List<Promotion_Detail> Details { get; set; }
    }
}
