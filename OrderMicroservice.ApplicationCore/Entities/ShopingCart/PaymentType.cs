using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Entities.ShopingCart
{
    public class PaymentType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<PaymentMethod> Methods { get; set; }
    }
}
