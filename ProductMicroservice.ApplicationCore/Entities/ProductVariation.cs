
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Entities
{
    public class ProductVariation
    {
        public int Product_Id { get; set; }

        public int Variation_value_Id { get; set; }

        public Product Product { get; set; }

        public VariationValue Variation { get; set; }
    }
}
