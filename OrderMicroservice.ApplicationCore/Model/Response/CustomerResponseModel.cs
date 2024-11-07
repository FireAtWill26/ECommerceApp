using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Model.Response
{
    public class CustomerResponseModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Profile_PIC { get; set; }

        public string UserId { get; set; }
    }
}
