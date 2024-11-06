using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.ApplicationCore.Entities
{
    public class Promotion_Detail
    {
        public int Id { get; set; }

        public int Promotion_Id { get; set; }

        public int Product_Category_Id { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string Product_Category_Name { get; set; }

        public Promotion Promotion { get; set; }
    }
}
