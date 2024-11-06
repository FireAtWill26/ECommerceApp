using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Entities
{
    public class CategoryVariation
    {
        public int Id { get; set; }

        public int Category_Id { get; set; }

        [Column("Variation_Name")]
        public string Name { get; set; }

        public List<VariationValue> Values { get; set; }

        public Category Category { get; set; }

        
    }
}
