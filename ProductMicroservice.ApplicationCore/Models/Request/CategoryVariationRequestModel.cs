using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Models.Request
{
    public class CategoryVariationRequestModel
    {
        public int Id { get; set; }

        public int Category_Id { get; set; }

        public string Name { get; set; }
    }
}
