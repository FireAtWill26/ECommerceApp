using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Entities
{
    public class VariationValue
    {
        public int Id { get; set; }

        public int variation_Id { get; set; }

        public string value { get; set; }

        public List<ProductVariation> ProductVariations { get; set; }

        public CategoryVariation Variation { get; set; }
    }
}
