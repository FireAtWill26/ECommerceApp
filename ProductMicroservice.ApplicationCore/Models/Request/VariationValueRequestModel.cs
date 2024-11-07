using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Models.Request
{
    public class VariationValueRequestModel
    {
        public int Id { get; set; }

        public int variation_Id { get; set; }

        public string value { get; set; }
    }
}
