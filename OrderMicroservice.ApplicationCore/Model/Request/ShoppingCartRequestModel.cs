
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Model.Request
{
    public class ShoppingCartRequestModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }
    }
}
