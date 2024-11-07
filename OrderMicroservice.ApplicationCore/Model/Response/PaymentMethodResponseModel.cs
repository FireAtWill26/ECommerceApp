
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Model.Response
{
    public class PaymentMethodResponseModel
    {
        public int Id { get; set; }

        public int PaymentTypeId { get; set; }

        public string Provider { get; set; }

        public string AccountNumber { get; set; }

        public DateTime Expiry { get; set; }

        public bool isDefault { get; set; }

        public int CustomerId { get; set; }
    }
}
